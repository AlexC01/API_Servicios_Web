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
    public class productsviewController : ApiController
    {
        private andinoshopEntities1 db = new andinoshopEntities1();

        // GET: api/products
        public List<Productos_Result2> GetProductos_Results()
        {
            return db.Productos_Result2().ToList();
        }
    }
}
