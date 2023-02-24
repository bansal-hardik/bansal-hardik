using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProductDetailsAPI.Model;

namespace ProductDetailsAPI.Data
{
    public class ProductDetailAPIContext:DbContext
    {
        public ProductDetailAPIContext(DbContextOptions<ProductDetailAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProductDetails> ProductDetail { get; set; }
    }
}
