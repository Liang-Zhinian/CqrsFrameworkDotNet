using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Business.Domain.Bus
{
    public class InterProcessBus : IInterProcessBus
    {

        private readonly string busName;
        private readonly string connectionString;

        public InterProcessBus(string host)
        {
            this.busName = "InterProcessBus";

            this.connectionString = host;
        }

        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = connectionString };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var bytes = Encoding.ASCII.GetBytes(message);
                    channel.ExchangeDeclare(busName, "fanout");
                    channel.BasicPublish(busName, string.Empty, null, bytes);
                }
            }
        }
    }
}
