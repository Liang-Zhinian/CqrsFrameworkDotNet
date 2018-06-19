using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Framing;

namespace RabbitMQTest
{
    class Program
    {
        static void HandleTimerCallback(object state)
        {
            SendMessage("xxxxxxxxx");
        }


        static void Main(string[] args)
        {
            Timer timer = new Timer(HandleTimerCallback, null, 1000, 2000);

            try
            {


                Console.WriteLine("Hello World!");

                var factory = new ConnectionFactory() { HostName = "localhost" };
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();
                {
                    channel.ExchangeDeclare(exchange: "book2", type: "fanout", durable: true, autoDelete: false);

                    var queueName = "book2events"; //channel.QueueDeclare().QueueName;
                    channel.QueueBind(queue: queueName,
                                      exchange: "book2",
                                      routingKey: "");

                    Console.WriteLine(" [*] Waiting for logs.");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;

                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine(" [x] {0}", message);

                        //channel.BasicAck(ea.DeliveryTag, false);

                    };
                    channel.BasicConsume(queue: queueName,
                                         autoAck: true,
                                         consumer: consumer);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        public static void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var body = Encoding.UTF8.GetBytes(message);

                    var properties = new BasicProperties();
                    properties.Headers = new Dictionary<string, object>
                    {
                        { "type", "1" }
                    };

                    channel.ExchangeDeclare("book2", "fanout", true, false);
                    channel.QueueDeclare("book2events", true, false, false, null);
                    channel.BasicPublish(exchange: "book2",
                                         routingKey: "",
                                         basicProperties: properties,
                                         body: body);

                    Console.WriteLine("Message sent: " + message);

                }
            }
        }
    }
}
