using ProductDetailsAPI.Data;
using ProductDetailsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailsAPI.Services
{
    public class ProductDetailsServices : IProductDetailsServices
    {
        private readonly ProductDetailAPIContext _context;

        public ProductDetailsServices(ProductDetailAPIContext context)
        {
            _context = context;
        }
        public void Create(ProductDetails product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.ProductDetail.Add(product);
        }

        public void Delete(ProductDetails product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.ProductDetail.Remove(product);
        }

        public IEnumerable<ProductDetails> GetDetails()
        {
            return _context.ProductDetail.ToList();
        }

        public ProductDetails GetProductDetailsById(int id)
        {
            return _context.ProductDetail.FirstOrDefault(p => p.DetailId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(ProductDetails product)
        {
            
        }
    }
}
