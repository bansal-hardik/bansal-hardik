using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailsAPI.DTO
{
    public class ProductDetailDto
    {
        
        public int DetailId { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }
        public string Design { get; set; }
    }
}
