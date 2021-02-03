using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Producer.Repositories;
using System.Threading.Tasks;

namespace RabbitMQ.Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly ProducerRepository producer;

        public ProducerController(ProducerRepository producer)
        {
            this.producer = producer;
        }

        [HttpPost]
        public async Task<IActionResult> SellProduct(string productName)
        {
            await producer.SellProductAsync(productName);

            return Ok();
        }
    }
}