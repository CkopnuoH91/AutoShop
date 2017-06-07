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

namespace AutoShop.Controllers
{
    public class BodiesController : ApiController
    {
        private AutoShopContext db = new AutoShopContext();

        // GET: api/Bodies
        public IQueryable<Body> GetBodies()
        {
            return db.Bodies;
        }

        // GET: api/Bodies/5
        [ResponseType(typeof(Body))]
        public IHttpActionResult GetBody(int id)
        {
            Body body = db.Bodies.Find(id);
            if (body == null)
            {
                return NotFound();
            }

            return Ok(body);
        }

        // PUT: api/Bodies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBody(int id, Body body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != body.Id)
            {
                return BadRequest();
            }

            db.Entry(body).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodyExists(id))
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

        // POST: api/Bodies
        [ResponseType(typeof(Body))]
        public IHttpActionResult PostBody(Body body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bodies.Add(body);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = body.Id }, body);
        }

        // DELETE: api/Bodies/5
        [ResponseType(typeof(Body))]
        public IHttpActionResult DeleteBody(int id)
        {
            Body body = db.Bodies.Find(id);
            if (body == null)
            {
                return NotFound();
            }

            db.Bodies.Remove(body);
            db.SaveChanges();

            return Ok(body);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BodyExists(int id)
        {
            return db.Bodies.Count(e => e.Id == id) > 0;
        }
    }
}