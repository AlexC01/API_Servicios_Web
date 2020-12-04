using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class orden
    {
        [Key]
        public int order_id { get; set; }
        public string consecutive { get; set; }
        public DateTime date_order { get; set; }
        public DateTime date_delivered { get; set; }
        
        public int client_id { get; set; }
        [ForeignKey("client_id")]

        public int address_id { get; set; }
        [ForeignKey("address_id")]

        public decimal subtotal { get; set; }
        public decimal tax_total { get; set; }
        public decimal delivery { get; set; }
        public int status_id { get; set; }
        [ForeignKey("status_id")]

        public decimal total { get; set; }



    }
}