//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ironika_Theme1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Delivery_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Delivery_Table()
        {
            this.Timeing_Table = new HashSet<Timeing_Table>();
        }
    
        public int DeliveryId { get; set; }
        public Nullable<int> SupperId { get; set; }
        public Nullable<int> Kind { get; set; }
        public Nullable<int> Price { get; set; }
        public string Timeing { get; set; }
    
        public virtual Supper_Table Supper_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timeing_Table> Timeing_Table { get; set; }
    }
}
