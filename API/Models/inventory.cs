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
    using System.Collections.Generic;
    
    public partial class inventory
    {
        public int inventory_id { get; set; }
        public double quantity { get; set; }
        public Nullable<int> measure_id { get; set; }
        public System.DateTime date_created { get; set; }
        public Nullable<System.DateTime> date_modify { get; set; }
        public decimal price { get; set; }
    
        public virtual product product { get; set; }
        public virtual user user { get; set; }
    }
}
