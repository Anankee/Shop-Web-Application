using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interface
{
    public interface IProductRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetProducts();
        void Update(Product product);
        void Remove(int id);
        
    }
}
