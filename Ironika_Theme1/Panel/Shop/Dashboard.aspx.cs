using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ironika_Theme1.Panel.Shop
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Supper"] == null)
                    Response.Redirect("../../Home");
                try
                {
                    Int64 Tottal_Day = 0; Int64 Tottal_Week = 0; Int64 Tottal_Year = 0;
                    int Ids = int.Parse(Session["Supper"].ToString());
                    int Year_Day = DateTime.Now.Year; int Month_Day = DateTime.Now.Month; int Day_Day = DateTime.Now.Day;
                    int ProductId = 0;
                    List<OrderDetail_Table> lst_Day = db.OrderDetail_Table.Where(r => r.Order_Table.SupperId == Ids && r.Order_Table.DateSales.Value.Year == Year_Day && r.Order_Table.DateSales.Value.Month == Month_Day && r.Order_Table.DateSales.Value.Day == Day_Day).ToList();
                    foreach (var item in lst_Day)
                        Tottal_Day += (item.Number.Value) * (item.Price.Value);
                    DivDay_Order.InnerHtml = NumberFormat(Tottal_Day);



                    DateTime Date_Week = DateTime.Now.AddDays(-7);

                    List<OrderDetail_Table> lst_week = db.OrderDetail_Table.Where(r => r.Order_Table.SupperId == Ids && r.Order_Table.DateSales.Value >= Date_Week).ToList();
                    foreach (var item in lst_week)
                        Tottal_Week += (item.Number.Value) * (item.Price.Value);
                    DivWeek_Order.InnerHtml = NumberFormat(Tottal_Week);

                    DateTime Date_Year = DateTime.Now.AddYears(-1);

                    List<OrderDetail_Table> lst_Year = db.OrderDetail_Table.Where(r => r.Order_Table.SupperId == Ids && r.Order_Table.DateSales.Value >= Date_Year).ToList();
                    foreach (var item in lst_Year)
                        Tottal_Year += (item.Number.Value) * (item.Price.Value);
                    DivAll_Order.InnerHtml = NumberFormat(Tottal_Year);
                }
                catch { }
            }
            catch { }
        }
        public string NumberFormat(Int64 Text)
        {
            int Length = Text.ToString().Length;
            string MyText = "";
            int i = Length - 3;
            int j = 3;
            while (Length > 3)
            {
                MyText = Text.ToString().Substring(i, j) + "," + MyText;
                i = i - 3;
                Length = Length - 3;
            }
            if (Length > 0)
                MyText = Text.ToString().Substring(0, Length) + "," + MyText;
            MyText = MyText.Substring(0, MyText.Length - 1);
            return MyText;
        }
    }
}