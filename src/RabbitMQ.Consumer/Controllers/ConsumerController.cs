using Microsoft.AspNetCore.Mvc;
using RabbitMQ.App.Repositories;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly ConsumerRepository consumer;

        public ConsumerController()
        {
            consumer = new ConsumerRepository();
        }

        [HttpGet]
        [Route("shipping")]
        public async Task<IActionResult> GetShipping()
        {
            return Ok(await consumer.GetMessageFromQueuesAsync("shipping"));
        }

        [HttpGet]
        [Route("stock")]
        public async Task<IActionResult> GetStock()
        {
            return Ok(await consumer.GetMessageFromQueuesAsync("stock"));
        }
    }
}
