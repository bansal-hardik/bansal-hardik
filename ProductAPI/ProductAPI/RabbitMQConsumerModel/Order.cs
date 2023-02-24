using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.RabbitMQConsumerModel
{
    /// <summary>
    /// Product Details Model For The Communication Between 
    /// ProductAPI service and ProductDetailAPI Services
    /// </summary>
    public class Order
    {
        public int DetailId { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }
        public string Design { get; set; }
    }
}
