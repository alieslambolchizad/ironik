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
    
    public partial class Location_Table
    {
        public int LocationId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Title { get; set; }
        public string MyLat { get; set; }
        public string MyLot { get; set; }
        public string Address { get; set; }
    
        public virtual User_Table User_Table { get; set; }
    }
}
