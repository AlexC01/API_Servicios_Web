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
    public class inventoryController : ApiController
    {
        private andinoshopEntities1 db = new andinoshopEntities1();
        public List<Inventario_Result2> GetInventario_Result()
        {
            return db.Inventario_Result2().ToList();
        }

        public IHttpActionResult Post(Models.inventoryCLS inventory)
        {
            db.InventarioGuardar_Result(0, inventory.product_id, inventory.user_id, inventory.quantity, inventory.measure_id, inventory.date_created, inventory.price ,"A");
            return CreatedAtRoute("DefaultApi", new { id = inventory.inventory_id }, inventory);
        }

        public IHttpActionResult Putinventario(int inventory_id, Models.inventoryCLS inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (inventory_id != inventory.inventory_id)
            {
                return BadRequest();
            }

            db.InventarioGuardar_Result(inventory.inventory_id, inventory.product_id, inventory.user_id, inventory.quantity, inventory.measure_id, inventory.date_created, inventory.price, "U");
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id)
        {
            inventory inventory = db.inventory.Find(id);
            if (inventory == null)
            {
                return NotFound();
            }

            db.inventory.Remove(inventory);
            db.SaveChanges();

            return Ok(inventory);
        }

    }
}
