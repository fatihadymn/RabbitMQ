using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ.Common
{
    public class ConnectionService
    {
        public IConnection RabbitMQConnection()
        {
            ConnectionFactory connection = new ConnectionFactory()
            {
                HostName = "rabbitmq",
                UserName = "test",
                Password = "test",
                Port = 5672,
                DispatchConsumersAsync = true
            };

            return connection.CreateConnection();
        }
    }
}
