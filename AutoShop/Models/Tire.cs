using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class Tire
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }

        public ICollection<Wheel> Wheels { get; set; }

        public Tire()
        {
            Wheels = new List<Wheel>();
        }
    }
}