using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class Car
    {
        public int Id { get; set; }
        public DateTime? OfTheYear { get; set; }
        public DateTime? UpToAYear { get; set; }

        public int? ModelId { get; set; }
        public virtual Model Model { get; set; }

        public int? TypeCarId { get; set; }
        public virtual TypeCar TypeCar { get; set; }

        public int? BodyId { get; set; }
        public virtual Body Body { get; set; }

        public int? EngineId { get; set; }
        public virtual Engine Engine { get; set; }

        public int? DriveTypeId { get; set; }
        public virtual DriveType DriveType { get; set; }
    }
}