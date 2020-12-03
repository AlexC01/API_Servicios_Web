﻿using API.Models;
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
    public class ordersviewController : ApiController
    {
        private andinoshopEntities1 db = new andinoshopEntities1();

        public List<Orders_Result1> GetOrders_Results()
        {
            return db.Orders_Result1().ToList();
        }
    }
}
