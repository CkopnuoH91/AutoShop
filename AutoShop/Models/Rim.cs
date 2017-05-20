﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class Rim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }

        public ICollection<Wheel> Wheels { get; set; }

        public Rim()
        {
            Wheels = new List<Wheel>();
        }
    }
}