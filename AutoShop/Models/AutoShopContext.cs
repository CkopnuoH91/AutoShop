using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShop.Models
{
    public class AutoShopContext : DbContext
    {
        public AutoShopContext() 
            : base("AutoShopDbConnection")
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }

        public DbSet<Engine> Engines { get; set; }
        public DbSet<Body>  Bodies { get; set; }

        public DbSet<Wheel> Wheels { get; set; }
        public DbSet<Rim> Rims { get; set; }
        public DbSet<Tire> Tires { get; set; }

    }
}
