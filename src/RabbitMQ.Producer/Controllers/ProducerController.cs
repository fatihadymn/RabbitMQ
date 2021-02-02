using Microsoft.AspNetCore.Mvc;
using RabbitMQ.App.Repositories;
using System.Threading.Tasks;

namespace RabbitMQ.Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly ProducerRepository producer;

        public ProducerController()
        {
            producer = new ProducerRepository();
        }

        [HttpPost]
        public async Task<IActionResult> SellProduct(string productName)
        {
            await producer.SellProductAsync(productName);

            return Ok();
        }
    }
}