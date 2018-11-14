using Library.DAL;
using Library.Interface;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product)
        {
            using(var context = new ShopContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }     
        }

        public Product GetById(int id)
        {
            using (var context = new ShopContext())
                return context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            using (var context = new ShopContext())
                return context.Products
                    .ToList();
        }

        public Product Delete(int id)
        {
            using(var context = new ShopContext())
            {
                var product = context.Products.Find(id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    return product;
                }                    
            }
            return null;
        }

        public void Update(Product product)
        {
            using(var context = new ShopContext())
            {
                var dbProduct = context.Products.Find(product.Id);
                if (dbProduct != null) {
                    context.Entry(dbProduct).CurrentValues.SetValues(product);
                    context.SaveChanges();
                }               
            }
        }
    }
}
