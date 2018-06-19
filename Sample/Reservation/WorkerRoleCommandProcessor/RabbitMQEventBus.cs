using System;
using System.Collections.Generic;
using System.Text;
using CqrsFramework.Bus;
using CqrsFramework.Events;
using CqrsFramework.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace WorkerRoleCommandProcessor
{
    public class RabbitMQEventBus : IHandlerRegistrar
    {
        private readonly Dictionary<Type, List<Action<IMessage>>> _routes = new Dictionary<Type, List<Action<IMessage>>>();

        public void RegisterHandler<T>(Action<T> handler) where T : IMessage
        {
            List<Action<IMessage>> handlers;
            if (!_routes.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<IMessage>>();
                _routes.Add(typeof(T), handlers);
            }
            handlers.Add(DelegateAdjuster.CastArgument<IMessage, T>(x => handler(x)));
        }

        public void Listen()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "InterProcessBus", type: "fanout", durable: true, autoDelete: false);

                var queueName = "TestQueue"; //channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName,
                                  exchange: "InterProcessBus",
                                  routingKey: "");

                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;

                    var message = Encoding.UTF8.GetString(body);

                    Console.WriteLine(" [x] {0}", message);

                    // to do: parse this event to the handler, then send ack to the chanel after this event been handled
                    //IEvent @event = null;
                    //using (var stream = new MemoryStream(body))
                    //using (var reader = new StreamReader(stream))
                    //{
                    //    //@event = (IEvent)this.serializer.Deserialize(reader);
                    //    var v = (SimpleClass)this.serializer.Deserialize(reader);
                    //}

                    var jsonObj = JsonConvert.DeserializeObject(message, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    var @event = (IEvent)jsonObj;
                    List<Action<IMessage>> handlers;
                    if (!_routes.TryGetValue(typeof(IEvent), out handlers)) return;
                    foreach (var handler in handlers)
                        handler(@event);

                    channel.BasicAck(ea.DeliveryTag, false);

                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);
            }
        }
    }
}
