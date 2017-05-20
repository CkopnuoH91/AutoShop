using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class Engine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Volume { get; set; }
        public int Power { get; set; }

        public ICollection<Car> Cars { get; set; }

        public Engine()
        {
            Cars = new List<Car>();
        }
    }
}