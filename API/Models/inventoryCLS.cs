using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class inventoryCLS
    {
        public int inventory_id { get; set; }
        public int product_id { get; set; }
        public int user_id { get; set; }
        public float quantity { get; set; }
        public int measure_id { get; set; }
        public DateTime date_created { get; set; }
    }
}