//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace online_store.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblorder
    {
        public int orderid { get; set; }
        public string customername { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<int> total { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> pid { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    }
}
