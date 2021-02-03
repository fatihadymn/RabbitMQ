using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Common;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer.Repositories
{
    public class ConsumerRepository:IConsumerRepository
    {
        public async Task<List<string>> GetMessageFromQueuesAsync(string queueName)
        {
            List<string> result = new List<string>();

            var service = new ConnectionService();

            using (var connection = service.RabbitMQConnection())
            using (var channel = connection.CreateModel())
            {
                var consumer = new AsyncEventingBasicConsumer(channel);

                consumer.Received += async (model, response) =>
                {
                    var message = Encoding.UTF8.GetString(response.Body.ToArray());

                    result.Add($"Message for {queueName} side : {message}");

                    channel.BasicAck(response.DeliveryTag, false);
                };

                channel.BasicConsume($"product.{queueName}", false, consumer);
            }

            return result;
        }
    }
}
