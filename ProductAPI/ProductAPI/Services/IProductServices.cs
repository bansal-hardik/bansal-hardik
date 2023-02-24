
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Services
{
    /// <summary>
    /// Interface for the Task to be Performed In The API
    /// </summary>
    public interface IProductServices
    {
        bool SaveChanges();
        IEnumerable<Product> GetDetails();
        Product GetProductById(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
