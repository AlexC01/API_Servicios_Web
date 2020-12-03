using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]

    public class clientsController : ApiController
    {

        private andinoshopEntities1 db = new andinoshopEntities1();

        // GET: api/clients
        public IQueryable<client> Getclient()
        {
            return db.client;
        }

        // GET: api/clients/5
        [ResponseType(typeof(client))]
        public IHttpActionResult Getclient(int id)
        {
            client client = db.client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putclient(int id, client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.client_id)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientExists(id))
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

        // POST: api/clients
        [ResponseType(typeof(client))]
        public IHttpActionResult Postclient(client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.client.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.client_id }, client);
        }

        // DELETE: api/clients/5
        [ResponseType(typeof(client))]
        public IHttpActionResult Deleteclient(int id)
        {
            client client = db.client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.client.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clientExists(int id)
        {
            return db.client.Count(e => e.client_id == id) > 0;
        }
    }
}