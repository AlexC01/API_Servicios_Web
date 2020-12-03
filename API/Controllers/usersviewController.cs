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
    public class usersviewController : ApiController
    {
        private andinoshopEntities1 db = new andinoshopEntities1();

        // GET: api/products
        public List<Usuario_Result> GetProductos_Results()
        {
            return db.Usuario_Result().ToList();
        }
    }
}
