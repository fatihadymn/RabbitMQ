using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer.Repositories
{
    public interface IConsumerRepository
    {
        Task<List<string>> GetMessageFromQueuesAsync(string queueName);
    }
}
