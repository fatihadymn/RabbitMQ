using RabbitMQ.Client;
using RabbitMQ.Common;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Producer.Repositories
{
    public class ProducerRepository:IProducerRepository
    {
        public async Task SellProductAsync(string productName)
        {
            var service = new ConnectionService();

            using (var connection = service.RabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("product.exchange", ExchangeType.Fanout, true, false, null);

                    channel.QueueDeclare("product.shipping", true, false, false, null);
                    channel.QueueDeclare("product.stock", true, false, false, null);

                    channel.QueueBind("product.shipping", "product.exchange", "");
                    channel.QueueBind("product.stock", "product.exchange", "");

                    var address = new PublicationAddress(ExchangeType.Fanout, "product.exchange", "");

                    channel.BasicPublish(address, null, Encoding.UTF8.GetBytes($"{productName} was sold"));
                }
            }
        }
    }
}
