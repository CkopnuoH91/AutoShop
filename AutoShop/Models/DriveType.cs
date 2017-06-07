using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class DriveType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Car> Cars { get; set; }

        public DriveType()
        {
            Cars = new List<Car>();
        }
    }
}