using Common;
using MassTransit;
using System.Threading.Tasks;

namespace MQ_2.Models
{
    public class OrderConsumer : IConsumer<UtilityPaymentConsumerModel>
    {
        public async Task Consume(ConsumeContext<UtilityPaymentConsumerModel> context)
        {
            var data = context.Message;
        }
    }
}
