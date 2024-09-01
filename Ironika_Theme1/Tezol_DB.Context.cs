﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Tezol_DBEntities : DbContext
    {
        public Tezol_DBEntities()
            : base("name=Tezol_DBEntities")
        {
        }

        //public Tezol_DBEntities(DbContexOption)
        //{

        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address_Table> Address_Table { get; set; }
        public virtual DbSet<Ads_Table> Ads_Table { get; set; }
        public virtual DbSet<AdsShop_Table> AdsShop_Table { get; set; }
        public virtual DbSet<Baner_Table> Baner_Table { get; set; }
        public virtual DbSet<BanerApp_Table> BanerApp_Table { get; set; }
        public virtual DbSet<Brands_Table> Brands_Table { get; set; }
        public virtual DbSet<Category_Table> Category_Table { get; set; }
        public virtual DbSet<Citypost_Table> Citypost_Table { get; set; }
        public virtual DbSet<Contact_Table> Contact_Table { get; set; }
        public virtual DbSet<Content_Table> Content_Table { get; set; }
        public virtual DbSet<Country_Table> Country_Table { get; set; }
        public virtual DbSet<Delivery_Table> Delivery_Table { get; set; }
        public virtual DbSet<Faq_Table> Faq_Table { get; set; }
        public virtual DbSet<Following_Table> Following_Table { get; set; }
        public virtual DbSet<Group_Table> Group_Table { get; set; }
        public virtual DbSet<GroupShop_Table> GroupShop_Table { get; set; }
        public virtual DbSet<Like_Table> Like_Table { get; set; }
        public virtual DbSet<Location_Table> Location_Table { get; set; }
        public virtual DbSet<Menu_Table> Menu_Table { get; set; }
        public virtual DbSet<Order_Table> Order_Table { get; set; }
        public virtual DbSet<OrderDetail_Table> OrderDetail_Table { get; set; }
        public virtual DbSet<OwenerGroup_Table> OwenerGroup_Table { get; set; }
        public virtual DbSet<OwnerProduct_Table> OwnerProduct_Table { get; set; }
        public virtual DbSet<Payment_Table> Payment_Table { get; set; }
        public virtual DbSet<People_Table> People_Table { get; set; }
        public virtual DbSet<Product_Table> Product_Table { get; set; }
        public virtual DbSet<ProductShop_Table> ProductShop_Table { get; set; }
        public virtual DbSet<Province_Table> Province_Table { get; set; }
        public virtual DbSet<Provincepost_Table> Provincepost_Table { get; set; }
        public virtual DbSet<Rating_Table> Rating_Table { get; set; }
        public virtual DbSet<Region_Table> Region_Table { get; set; }
        public virtual DbSet<Review_Table> Review_Table { get; set; }
        public virtual DbSet<SlideMenu_Table> SlideMenu_Table { get; set; }
        public virtual DbSet<Slider_Table> Slider_Table { get; set; }
        public virtual DbSet<Story_Table> Story_Table { get; set; }
        public virtual DbSet<Supper_Table> Supper_Table { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Theme_Table> Theme_Table { get; set; }
        public virtual DbSet<Ticket_Table> Ticket_Table { get; set; }
        public virtual DbSet<Timeing_Table> Timeing_Table { get; set; }
        public virtual DbSet<User_Table> User_Table { get; set; }
        public virtual DbSet<View_Group> View_Group { get; set; }
        public virtual DbSet<View_Total> View_Total { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
