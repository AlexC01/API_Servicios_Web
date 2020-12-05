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
    public class productsController : ApiController
    {
        private andinoshopEntities1 db = new andinoshopEntities1();

        // GET: api/products
        public List<Productos_Result2> GetProductos_Results()
        {
            return db.Productos_Result2().ToList();
        }

        // GET: api/products/5
        [ResponseType(typeof(product))]
        public IHttpActionResult Getproduct(int id)
        {
            product product = db.product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproduct(int id, product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.product_id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productExists(id))
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

        // POST: api/products
        [ResponseType(typeof(product))]
        public IHttpActionResult Postproduct(product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.product.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.product_id }, product);
        }

        // DELETE: api/products/5
        [ResponseType(typeof(product))]
        public IHttpActionResult Deleteproduct(int id)
        {
            product product = db.product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.product.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool productExists(int id)
        {
            return db.product.Count(e => e.product_id == id) > 0;
        }
    }
}