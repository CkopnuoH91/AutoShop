using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoShop.Models;
using Microsoft.VisualBasic.FileIO;

namespace AutoShop.Controllers
{
    public class BrandsController : ApiController
    {
        private AutoShopContext db = new AutoShopContext();

        // GET: api/Brands
        public IQueryable<Brand> GetBrands()
        {
            //FillDataBase();           
            return db.Brands;
        }

        private void FillDataBase()
        {
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\CkopnuoH\Desktop\базы данных авто\Cars Demo\Cars Demo.csv"))
            {

                db.EngineTypes.AddRange(new List<EngineType>()
                {
                    new EngineType() { Type = "Бензиновый двигатель" },
                    new EngineType() { Type = "Дизель" },
                    new EngineType() { Type = "Электрический двигатель" },
                    new EngineType() { Type = "гибрид" }
                });
                db.SaveChanges();

                db.DriveTypes.AddRange(new List<DriveType>()
                {
                    new DriveType() { Type="Привод на передние колеса" },
                    new DriveType() { Type="Привод на задние колеса" },
                    new DriveType() { Type="Привод на все колеса" },
                });
                db.SaveChanges();

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");

                Brand brand = new Brand();
                Model model = new Model();
                Body body = new Body();
                TypeCar typeCar = new TypeCar();
                Engine engine = new Engine();
                DriveType driveType = new DriveType();
                DateTime? OfTheYear;
                DateTime? UpToAYear;
                Car car;

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (db.Brands.ToList().Find(b => b.Name == fields[0]) == null)
                    {
                        brand = new Brand { Name = fields[0] };
                        db.Brands.Add(brand);
                        db.SaveChanges();
                    }

                    if (db.Models.ToList().Find(m => m.Name == fields[1]) == null)
                    {
                        model = new Model { Name = fields[1], Brand = brand };
                        db.Models.Add(model);
                        db.SaveChanges();
                    }

                    if (db.Bodies.ToList().Find(b => b.Type == fields[3]) == null)
                    {
                        body = new Body { Type = fields[3] };
                        db.Bodies.Add(body);
                        db.SaveChanges();
                    }

                    if (db.TypesOfCar.ToList().Find(t => t.Type == fields[2]) == null)
                    {
                        typeCar = new TypeCar { Type = fields[2] };
                        db.TypesOfCar.Add(typeCar);
                        db.SaveChanges();
                    }


                    int? vol = null;
                    if (fields[8] == "")
                    {
                        vol = null;
                    }
                    else
                    {
                        vol = int.Parse(fields[8]);
                    }

                    if (db.Engines.ToList().Find(e => (e.Power == int.Parse(fields[7]) && e.Volume == vol)) == null)
                    {
                        engine = new Engine { Power = int.Parse(fields[7]) };

                        if (fields[8] == "")
                        {
                            engine.Volume = null;
                        }
                        else
                        {
                            engine.Volume = int.Parse(fields[8]);
                        }
                        if (fields[9].Contains("Бензиновый двигатель"))
                        {
                            engine.EngineType = db.EngineTypes.ToList().Find(e => e.Type == "Бензиновый двигатель");
                        }
                        if (fields[9].Contains("Дизель"))
                        {
                            engine.EngineType = db.EngineTypes.ToList().Find(e => e.Type == "Дизель");
                        }
                        if (fields[9].Contains("Электрический двигатель"))
                        {
                            engine.EngineType = db.EngineTypes.ToList().Find(e => e.Type == "Электрический двигатель");
                        }
                        if (fields[9].Contains("гибрид"))
                        {
                            engine.EngineType = db.EngineTypes.ToList().Find(e => e.Type == "гибрид");
                        }

                        db.Engines.Add(engine);
                        db.SaveChanges();
                    }

                    if (fields[4] != "")
                    {
                        int year = int.Parse(fields[4].Substring(0, 4));
                        int month = int.Parse(fields[4].Substring(4, 2));
                        OfTheYear = new DateTime(year, month, 1).Date;
                    }
                    else { OfTheYear = null; }

                    if (fields[5] != "")
                    {
                        int year = int.Parse(fields[5].Substring(0, 4));
                        int month = int.Parse(fields[5].Substring(4, 2));
                        UpToAYear = new DateTime(year, month, 1).Date;
                    }
                    else { UpToAYear = null; }

                    if (fields[9].Contains("Привод на передние колеса"))
                    {
                        driveType = db.DriveTypes.ToList().Find(e => e.Type == "Привод на передние колеса");
                    }
                    if (fields[9].Contains("Привод на задние колеса"))
                    {
                        driveType = db.DriveTypes.ToList().Find(e => e.Type == "Привод на задние колеса");
                    }
                    if (fields[9].Contains("Привод на все колеса"))
                    {
                        driveType = db.DriveTypes.ToList().Find(e => e.Type == "Привод на все колеса");
                    }

                    string sModel = fields[1];
                    string sTypeCar = fields[2];
                    string sbody = fields[3];
                    int iPower = int.Parse(fields[7]);
                    int? iVolume = vol;

                    car = new Car
                    {
                        Model = db.Models.ToList().Find(m => m.Name == sModel),
                        TypeCar = db.TypesOfCar.ToList().Find(t => t.Type == sTypeCar),
                        Body = db.Bodies.ToList().Find(b => b.Type == sbody),
                        Engine = db.Engines.ToList().Find(e => (e.Power == iPower) && (e.Volume == iVolume)),
                        OfTheYear = OfTheYear,
                        UpToAYear = UpToAYear,
                        DriveType = driveType
                    };
                    db.Cars.Add(car);
                    db.SaveChanges();
                }
            }
            db.SaveChanges();
        }

        // GET: api/Brands/5
        [ResponseType(typeof(Brand))]
        public IHttpActionResult GetBrand(int id)
        {
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        // PUT: api/Brands/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBrand(int id, Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brand.Id)
            {
                return BadRequest();
            }

            db.Entry(brand).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Brands
        [ResponseType(typeof(Brand))]
        public IHttpActionResult PostBrand(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Brands.Add(brand);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = brand.Id }, brand);
        }

        // DELETE: api/Brands/5
        [ResponseType(typeof(Brand))]
        public IHttpActionResult DeleteBrand(int id)
        {
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            db.Brands.Remove(brand);
            db.SaveChanges();

            return Ok(brand);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrandExists(int id)
        {
            return db.Brands.Count(e => e.Id == id) > 0;
        }
    }
}