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
    
    public partial class tblsupplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblsupplier()
        {
            this.tblstocks = new HashSet<tblstock>();
        }
    
        public int sid { get; set; }
        public string sname { get; set; }
        public Nullable<int> contact { get; set; }
        public string adress { get; set; }
        public Nullable<int> status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblstock> tblstocks { get; set; }
    }
}