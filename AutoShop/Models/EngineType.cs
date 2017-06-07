using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class EngineType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Engine> Engines { get; set; }

        public EngineType()
        {
            Engines = new List<Engine>();
        }
    }
}