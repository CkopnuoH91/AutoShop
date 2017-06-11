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
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }

        public DbSet<Engine> Engines { get; set; }
        public DbSet<EngineType> EngineTypes { get; set; }

        public DbSet<Body> Bodies { get; set; }

        public DbSet<DriveType> DriveTypes { get; set; }

        public DbSet<TypeCar> TypesOfCar { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
