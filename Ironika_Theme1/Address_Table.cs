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
    
    public partial class Address_Table
    {
        public int AddressId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Title { get; set; }
        public string Tele { get; set; }
        public string PersonName { get; set; }
        public string PostalCode { get; set; }
        public Nullable<int> RegionId { get; set; }
        public string Address { get; set; }
    
        public virtual User_Table User_Table { get; set; }
    }
}
