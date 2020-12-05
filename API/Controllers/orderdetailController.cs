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
    public class orderdetailController : ApiController
    {
        private andinoshopEntities1 db = new andinoshopEntities1();

        public List<OrderDetail_Result1> GetOrderDetail_Results()
        {
            return db.OrderDetail_Result1().ToList();
        }

        public IHttpActionResult Post(Models.orderdetailCLS orderdetail)
        {
            db.OrderDetailGuardar_Result(0, orderdetail.order_id, orderdetail.product_id, orderdetail.quantity, orderdetail.price, orderdetail.tax, orderdetail.subtotal, "A");
            return CreatedAtRoute("DefaultApi", new { id = orderdetail.order_detail }, orderdetail);
        }

        public IHttpActionResult Putorderdetail(int order_detail, Models.orderdetailCLS orderdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (order_detail != orderdetail.order_detail)
            {
                return BadRequest();
            }

            db.OrderDetailGuardar_Result(orderdetail.order_detail, orderdetail.order_id, orderdetail.product_id, orderdetail.quantity, orderdetail.price, orderdetail.tax, orderdetail.subtotal, "U");
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Deleteorderdetail(int id)
        {
            order_detail order_detail = db.order_detail.Find(id);
            if (order_detail == null)
            {
                return NotFound();
            }

            db.order_detail.Remove(order_detail);
            db.SaveChanges();

            return Ok(order_detail);
        }
    }
}
