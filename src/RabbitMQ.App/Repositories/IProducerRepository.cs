using System.Threading.Tasks;

namespace RabbitMQ.App.Repositories
{
    public interface IProducerRepository
    {
        Task SellProductAsync(string productName);
    }
}
