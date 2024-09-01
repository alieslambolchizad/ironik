using Ironika_Theme1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ironika_Theme1.Panel.Shop
{
    public partial class AllOrder : System.Web.UI.Page
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Supper"] == null)
                Response.Redirect("../../Home");

        }
        public string NumberFormat_Register(int UserId)
        {
            try
            {
                var Objs = db.User_Table.FirstOrDefault(r => r.UserId == UserId);
                if (Objs != null)
                    return Objs.Name + " " + Objs.Lastname;
                else
                    return "";
            }
            catch { return ""; }
        }
        
        public string NumberFormat_RegisterTele(int UserId)
        {
            try
            {
                var Objs = db.User_Table.FirstOrDefault(r => r.UserId == UserId);
                if (Objs != null)
                    return Objs.Tele;
                else
                    return "";
            }
            catch { return ""; }
        }
        public string NumberFormat_RegisterEmail(int UserId)
        {
            try
            {
                var Objs = db.User_Table.FirstOrDefault(r => r.UserId == UserId);
                if (Objs != null)
                    return Objs.Email;
                else
                    return "";
            }
            catch { return ""; }
        }

        public string NumberFormat_Date(DateTime DateSales)
        {
            return Date_Manager.ConvertDate(DateSales);
        }

        public string NumberFormat_Price(Int64 Price)
        {
            try
            {

                int Length = (Price).ToString().Length;
                string MyText = "";
                int i = Length - 3;
                int j = 3;
                while (Length > 3)
                {
                    MyText = (Price).ToString().Substring(i, j) + "." + MyText;
                    i = i - 3;
                    Length = Length - 3;
                }
                if (Length > 0)
                    MyText = (Price).ToString().Substring(0, Length) + "." + MyText;
                MyText = MyText.Substring(0, MyText.Length - 1);
                return MyText;
            }
            catch { return ""; }

        }
        protected void ObjectDataSource_Project_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["SupperId"] = Session["Supper"].ToString();
            e.InputParameters["Text"] = "";
        }

        protected void List_Project_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)e.CommandSource;
                int OrderTotalId = int.Parse(lb.CommandArgument.ToString());
                Hi_Order.Value = OrderTotalId.ToString();
                var Objs = db.Order_Table.FirstOrDefault(r => r.OrderId == OrderTotalId);
                if (Objs != null)
                {
                    Hi_Order.Value = Objs.FactorCode;
                    DivNo.InnerText = "صورتحساب :" + "100250" + Objs.OrderId;
                    DivNo1.InnerText = "صورتحساب :" + "100250" + Objs.OrderId;
                    DivAllPrice.InnerHtml = "";
                    DivCount.InnerHtml = "";
                    DivName.InnerHtml = "<i class='fa fa-globe'></i> نام خریدار:" + Objs.User_Table.Name + " " + Objs.User_Table.Lastname;
                    DivDate.InnerHtml = "تاریخ :" + Date_Manager.ConvertDate(Objs.DateSales.Value);
                    DivOner.InnerHtml = "<strong>" + Objs.User_Table.Name + " " + Objs.User_Table.Lastname + "</strong><br><b>تلفن : </b>" + Objs.User_Table.Tele + "<br/>";
                    int ?LocationId = Objs.LocationId;
                    var ObjsLocation = db.Location_Table.FirstOrDefault(r => r.LocationId == LocationId);
                    if (ObjsLocation != null)
                    {
                        DivDelivery.InnerHtml = "<strong>" + Objs.User_Table.Name+" "+ Objs.User_Table.Lastname + "</strong><br><b>تلفن : </b>" + Objs.User_Table.Tele + "<br/>";
                        DivAddress.InnerHtml = ObjsLocation.Address;
                    }

                    List<OrderDetail_Table> lst = db.OrderDetail_Table.Where(r => r.OrderId == OrderTotalId).ToList();
                    string Text = "<table class='table table-striped'><thead><tr><th>تعداد</th><th>محصول</th><th>کد محصول #</th><th>گروه - برند</th><th>جمع کل</th></tr></thead><tbody>";
                    Int64 Tottal = 0; int ProductId = 0;
                    for (int i = 0; i < lst.Count; i++)
                    {
                        ProductId = lst[i].ProductShopId.Value;
                        var ObjsPro = db.ProductShop_Table.FirstOrDefault(r => r.ProductId == ProductId);
                        Tottal += (lst[i].Price.Value) * (lst[i].Number.Value);
                        Text += "<tr><td>" + lst[i].Number.Value + "</td><td>" + ObjsPro.Name + "</td><td>" + ObjsPro.ProductId + "</td><td>" + ObjsPro.GroupShop_Table.Name + "</td><td>" + NumberFormat_Price((lst[i].Price.Value) * (lst[i].Number.Value)) + "</td></tr>";
                    }
                    DivCount.InnerHtml = lst.Count.ToString();
                    DivTottal.InnerHtml = NumberFormat_Price(Tottal) + " تومان";
                    DivAllPrice.InnerHtml = NumberFormat_Price(Tottal) + " تومان";


                    DivTabel.InnerHtml = Text + "</tbody></table>";
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalRegister", "openModalRegister();", true);
            }
            catch (Exception ex)
            {

            }
        }
        protected void BtnPrint_ServerClick(object sender, EventArgs e)
        {
            //Response.Redirect("Print.aspx?sid=" + Hi_Order.Value);
        }
    }
}