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
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace AutoShop.Controllers
{
    public class TypeCarsController : ApiController
    {
        private AutoShopContext db = new AutoShopContext();

        // GET: api/TypeCars
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<TypeCar> GetTypesOfCar()
        {
            return db.TypesOfCar;
        }

        // GET: api/TypeCars/5
        [ResponseType(typeof(TypeCar))]
        public IHttpActionResult GetTypeCar(int id)
        {
            TypeCar typeCar = db.TypesOfCar.Find(id);
            if (typeCar == null)
            {
                return NotFound();
            }

            return Ok(typeCar);
        }

        // PUT: api/TypeCars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeCar(int id, TypeCar typeCar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeCar.Id)
            {
                return BadRequest();
            }

            db.Entry(typeCar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeCarExists(id))
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

        // POST: api/TypeCars
        [ResponseType(typeof(TypeCar))]
        public IHttpActionResult PostTypeCar(TypeCar typeCar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypesOfCar.Add(typeCar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeCar.Id }, typeCar);
        }

        // DELETE: api/TypeCars/5
        [ResponseType(typeof(TypeCar))]
        public IHttpActionResult DeleteTypeCar(int id)
        {
            TypeCar typeCar = db.TypesOfCar.Find(id);
            if (typeCar == null)
            {
                return NotFound();
            }

            db.TypesOfCar.Remove(typeCar);
            db.SaveChanges();

            return Ok(typeCar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeCarExists(int id)
        {
            return db.TypesOfCar.Count(e => e.Id == id) > 0;
        }
    }
}