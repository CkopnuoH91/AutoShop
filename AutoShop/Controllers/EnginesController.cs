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
using System.Web.Http.OData.Query;
using System.Web.Http.OData;

namespace AutoShop.Controllers
{
    public class EnginesController : ApiController
    {
        private AutoShopContext db = new AutoShopContext();

        // GET: api/Engines
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<Engine> GetEngines()
        {
            return db.Engines;
        }

        // GET: api/Engines/5
        [ResponseType(typeof(Engine))]
        public IHttpActionResult GetEngine(int id)
        {
            Engine engine = db.Engines.Find(id);
            if (engine == null)
            {
                return NotFound();
            }

            return Ok(engine);
        }

        // PUT: api/Engines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEngine(int id, Engine engine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != engine.Id)
            {
                return BadRequest();
            }

            db.Entry(engine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngineExists(id))
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

        // POST: api/Engines
        [ResponseType(typeof(Engine))]
        public IHttpActionResult PostEngine(Engine engine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Engines.Add(engine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = engine.Id }, engine);
        }

        // DELETE: api/Engines/5
        [ResponseType(typeof(Engine))]
        public IHttpActionResult DeleteEngine(int id)
        {
            Engine engine = db.Engines.Find(id);
            if (engine == null)
            {
                return NotFound();
            }

            db.Engines.Remove(engine);
            db.SaveChanges();

            return Ok(engine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EngineExists(int id)
        {
            return db.Engines.Count(e => e.Id == id) > 0;
        }
    }
}