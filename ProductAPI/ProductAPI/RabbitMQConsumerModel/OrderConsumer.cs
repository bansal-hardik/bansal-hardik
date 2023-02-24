using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.RabbitMQConsumerModel
{
    /// <summary>
    /// Consumer Class For The RabbitMQ 
    /// Data Coming From ProductDetailsAPI to ProductAPI
    /// </summary>
    public class OrderConsumer : IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            var data = context.Message;
            // message received.
        }
    }
}
