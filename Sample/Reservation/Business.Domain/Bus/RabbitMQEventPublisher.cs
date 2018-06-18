using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CqrsFramework.Events;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing;

namespace Business.Domain.Bus
{
    public class RabbitMQEventPublisher : IEventPublisher
    {
        private readonly string busName;
        private readonly string connectionString;

        //private NLog.Logger logger = NLog.LogManager.GetLogger("BusEventPublisher");

        public RabbitMQEventPublisher(string host)
        {
            this.busName = "InterProcessBus";

            this.connectionString = host;
        }

        public void Publish<T>(T @event) where T : IEvent
        {
            string message = JsonConvert.SerializeObject(@event);
            SendMessage(message);
        }


        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = connectionString };
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

                    channel.ExchangeDeclare(busName, "fanout", true, false);
                    channel.QueueDeclare("TestQueue", true, false, false, null);
                    channel.BasicPublish(exchange: busName,
                                         routingKey: "",
                                         basicProperties: properties,
                                         body: body);
                    
                }
            }
        }
    }
}
