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
    public class DriveTypesController : ApiController
    {
        private AutoShopContext db = new AutoShopContext();

        // GET: api/DriveTypes
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<DriveType> GetDriveTypes()
        {
            return db.DriveTypes;
        }

        // GET: api/DriveTypes/5
        [ResponseType(typeof(DriveType))]
        public IHttpActionResult GetDriveType(int id)
        {
            DriveType driveType = db.DriveTypes.Find(id);
            if (driveType == null)
            {
                return NotFound();
            }

            return Ok(driveType);
        }

        // PUT: api/DriveTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriveType(int id, DriveType driveType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driveType.Id)
            {
                return BadRequest();
            }

            db.Entry(driveType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriveTypeExists(id))
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

        // POST: api/DriveTypes
        [ResponseType(typeof(DriveType))]
        public IHttpActionResult PostDriveType(DriveType driveType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DriveTypes.Add(driveType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = driveType.Id }, driveType);
        }

        // DELETE: api/DriveTypes/5
        [ResponseType(typeof(DriveType))]
        public IHttpActionResult DeleteDriveType(int id)
        {
            DriveType driveType = db.DriveTypes.Find(id);
            if (driveType == null)
            {
                return NotFound();
            }

            db.DriveTypes.Remove(driveType);
            db.SaveChanges();

            return Ok(driveType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DriveTypeExists(int id)
        {
            return db.DriveTypes.Count(e => e.Id == id) > 0;
        }
    }
}