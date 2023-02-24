using AutoMapper;
using ProductAPI.Data;
using ProductAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Services
{
    /// <summary>
    /// GET PUT DELETE UPDATE Services In the API
    /// </summary>
    public class ProductServices : IProductServices
    {
        private readonly ProductAPIContext _context;
        private readonly IMapper _mapper;

        public ProductServices(ProductAPIContext context)
        {
            _context = context;
            
        }

        public void Create(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.ProductApi.Add(product);
        }

        public void Delete(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.ProductApi.Remove(product);
        }

        public IEnumerable<Product> GetDetails()
        {
            
            return _context.ProductApi.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.ProductApi.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public void Update(Product product)
        {
            
        }
    }
}
