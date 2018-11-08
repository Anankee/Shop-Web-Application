using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext() {}

        public DbSet<Product> Products { get; set; }
    }
}
