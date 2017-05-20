using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class Body
    {
        public int Id { get; set; }
        public string Color { get; set; }

        public ICollection<Car> Cars { get; set; }

        public Body()
        {
            Cars = new List<Car>();
        }
    }
}