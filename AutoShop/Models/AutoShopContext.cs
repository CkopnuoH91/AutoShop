using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoshop.Models
{
    public class AutoShopContext : DbContext
    {
        public AutoShopContext() 
            : base("AutoShopDbConnection")
        {
        }

        public DbSet<Brand> Brands { get; set; }

    }
}
