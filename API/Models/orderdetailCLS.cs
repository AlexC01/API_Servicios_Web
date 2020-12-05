using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class orderdetailCLS
    {
        public int order_detail { get; set; }
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public decimal tax { get; set; }
        public decimal subtotal { get; set; }
    }
}