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
    public class EngineTypesController : ApiController
    {
        private AutoShopContext db = new AutoShopContext();

        // GET: api/EngineTypes
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<EngineType> GetEngineTypes()
        {
            return db.EngineTypes;
        }

        // GET: api/EngineTypes/5
        [ResponseType(typeof(EngineType))]
        public IHttpActionResult GetEngineType(int id)
        {
            EngineType engineType = db.EngineTypes.Find(id);
            if (engineType == null)
            {
                return NotFound();
            }

            return Ok(engineType);
        }

        // PUT: api/EngineTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEngineType(int id, EngineType engineType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != engineType.Id)
            {
                return BadRequest();
            }

            db.Entry(engineType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngineTypeExists(id))
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

        // POST: api/EngineTypes
        [ResponseType(typeof(EngineType))]
        public IHttpActionResult PostEngineType(EngineType engineType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EngineTypes.Add(engineType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = engineType.Id }, engineType);
        }

        // DELETE: api/EngineTypes/5
        [ResponseType(typeof(EngineType))]
        public IHttpActionResult DeleteEngineType(int id)
        {
            EngineType engineType = db.EngineTypes.Find(id);
            if (engineType == null)
            {
                return NotFound();
            }

            db.EngineTypes.Remove(engineType);
            db.SaveChanges();

            return Ok(engineType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EngineTypeExists(int id)
        {
            return db.EngineTypes.Count(e => e.Id == id) > 0;
        }
    }
}