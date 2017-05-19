using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autoshop.Models
{
    public class Brand
    {

        public int BrandId { get; set; }

        public string Name { get; set; }
        public string Country { get; set; } 
    }
}