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
    
    public partial class Review_Table
    {
        public int ReviewId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> SupperId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string Description { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<System.DateTime> RegisterDate { get; set; }
        public Nullable<bool> State { get; set; }
    
        public virtual Product_Table Product_Table { get; set; }
        public virtual User_Table User_Table { get; set; }
    }
}
