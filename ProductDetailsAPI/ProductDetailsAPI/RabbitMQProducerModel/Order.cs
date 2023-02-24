using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailsAPI.RabbitMQProducerModel
{
    public class Order
    {
        public int DetailId { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }
        public string Design { get; set; }
    }
}
