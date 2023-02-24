using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ProductDetailsAPI.DTO;
using ProductDetailsAPI.RabbitMQProducerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestRabbitController : ControllerBase
    {
        private readonly IBusControl _bus;

        public TestRabbitController(IBusControl bus)
        {
            _bus = bus;
        }

        [HttpPost]
        [Route("createorder")]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            Uri uri = new Uri("rabbitmq://localhost/productqueue");

            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(order);

            return Ok("Success");
        }

    }
}
