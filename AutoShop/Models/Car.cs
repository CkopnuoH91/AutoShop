using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class Car
    {
        public int Id { get; set; }

        public int? ModelId { get; set; }
        public virtual Model Model { get; set; }

        public int? EngineId { get; set; }
        public virtual Engine Engine { get; set; }

        public int? WheelId { get; set; }
        public virtual Wheel Wheel { get; set; }

        public int? BodyId { get; set; }
        public virtual Body Body { get; set; }
    }
}