using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class ordenController : ApiController
    {
        private andinoshopEntities1 db = new andinoshopEntities1();

        public List<Orders_Result3> GetOrders_Results()
        {
            return db.Orders_Result3().ToList();
        }

        public IHttpActionResult Post(Models.orden test)
        {
            db.OrdenGuardar_Result(test.order_id, null, test.date_order, test.client_id, test.address_id, test.subtotal, test.tax_total, test.delivery, test.status_id, test.total, "A");
            return CreatedAtRoute("DefaultApi", new { id = test.order_id}, test);
        }

        public IHttpActionResult Putorden(int order_id, Models.orden test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (order_id != test.order_id)
            {
                return BadRequest();
            }

            db.OrdenGuardar_Result(test.order_id, null, test.date_order, test.client_id, test.address_id, test.subtotal, test.tax_total, test.delivery, test.status_id, test.total, "U");
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Deleteorder(int id)
        {
            order order = db.order.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            db.order.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }
    }
}
