using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailsAPI.Model
{
    /// <summary>
    /// Product Detail Model
    /// </summary>
    public class ProductDetails
    {
        [Key]
        public int DetailId { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public int Price { get; set; }
        public string Design { get; set; }
    }
}
