//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    
    public partial class Inventario_Result3
    {
        public int inventory_id { get; set; }
        public int product_id { get; set; }
        public string Producto { get; set; }
        public int user_id { get; set; }
        public string username { get; set; }
        public double quantity { get; set; }
        public int measure_id { get; set; }
        public string measure { get; set; }
        public System.DateTime date_created { get; set; }
        public Nullable<System.DateTime> date_modify { get; set; }
    }
}
