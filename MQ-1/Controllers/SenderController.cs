using Common;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MQ_1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private readonly IBusControl bus;
        public SenderController(IBusControl _bus)
        {
            bus = _bus;
        }
        [HttpPost]
        public async Task<IActionResult> FanOutExchange(UtilityPaymentConsumerModel data)
        {
            if (data != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/myqueue");
                var endPoint = await bus.GetSendEndpoint(uri);
                await endPoint.Send(data);
                return Ok("Success");
            }
            return BadRequest();
        }

        //[HttpPost]
        //public async Task<IActionResult> Specific(OrderSender data)
        //{
        //    Uri uri = new Uri("rabbitmq://localhost/queue");
        //    var endPoint = await bus.GetSendEndpoint(uri);
        //    await endPoint.Send(data);
        //    return Ok("Success");
        //}
    }
}