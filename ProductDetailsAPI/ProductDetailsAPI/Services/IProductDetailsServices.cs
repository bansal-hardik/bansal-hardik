using ProductDetailsAPI.Model;
using System.Collections.Generic;

namespace ProductDetailsAPI.Services
{
    public interface IProductDetailsServices
    {
        bool SaveChanges();
        IEnumerable<ProductDetails> GetDetails();
        ProductDetails GetProductDetailsById(int id);
        void Create(ProductDetails product);
        void Update(ProductDetails product);
        void Delete(ProductDetails product);
    }
}