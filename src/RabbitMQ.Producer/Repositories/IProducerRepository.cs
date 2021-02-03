using System.Threading.Tasks;

namespace RabbitMQ.Producer.Repositories
{
    public interface IProducerRepository
    {
        Task SellProductAsync(string productName);
    }
}
