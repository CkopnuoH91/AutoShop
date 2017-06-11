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
    public class ModelsController : ApiController
    {
        private AutoShopContext db = new AutoShopContext();

        // GET: api/Models
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<Model> GetModels()
        {
            return db.Models;
        }

        // GET: api/Models/5
        [ResponseType(typeof(Model))]
        public IHttpActionResult GetModel(int id)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Models/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModel(int id, Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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

        // POST: api/Models
        [ResponseType(typeof(Model))]
        public IHttpActionResult PostModel(Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Models.Add(model);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        // DELETE: api/Models/5
        [ResponseType(typeof(Model))]
        public IHttpActionResult DeleteModel(int id)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Models.Remove(model);
            db.SaveChanges();

            return Ok(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelExists(int id)
        {
            return db.Models.Count(e => e.Id == id) > 0;
        }
    }
}