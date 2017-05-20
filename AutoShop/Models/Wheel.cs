using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class Wheel
    {
        public int Id { get; set; }

        public int? TireId { get; set; }
        public virtual Tire Tire { get; set; }

        public int? RimId { get; set; }
        public virtual Rim Rim { get; set; }

        public ICollection<Car> Cars { get; set; }

        public Wheel()
        {
            Cars = new List<Car>();
        }
    }
}