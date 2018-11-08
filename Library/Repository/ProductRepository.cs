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

        public IEnumerable<Product> GetProducts()
        {
            using (var context = new ShopContext())
                return context.Products
                    .ToList();
        }

        public void Remove(int id)
        {
            using(var context = new ShopContext())
            {
                var product = context.Products.Find(id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                    
            }
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
