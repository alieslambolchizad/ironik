using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ironika_Theme1.Panel.Shop
{
    public partial class Delivery : System.Web.UI.Page
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Supper"] == null)
                Response.Redirect("../../Home");
        }
        protected void List_Project_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int Id = int.Parse(List_Project.SelectedValue.ToString());
                hi_Id.Value = Id.ToString();

                Delivery_Table obj = (from k in db.Delivery_Table where k.DeliveryId == Id select k).Single();
                if (obj != null)
                {
                    DrpChoice.ClearSelection();
                    DrpChoice.Items[obj.Kind.Value].Selected = true;
                    TxtPrice.Text = obj.Price.Value.ToString();
                    TxtDate.Text = obj.Timeing;
                }

                else
                {
                    Cancle();
                }
            }
            catch { }
        }

        public string NumberFormat_Title(int Kind)
        {
           switch(Kind)
            {
                case 1:
                    return "پست پیشتاز";
                    break;
                case 2:
                    return "پیک ایرونیکا";
                    break;
                case 3:
                    return "پیک سوپرمارکت";
                    break;
                default:
                    return "";
                    break;
            }
        }
        public string NumberFormat(int Price)
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
        protected void submit_register_Click(object sender, EventArgs e)
        {
            try
            {

                if (hi_Id.Value == "")
                {
                    int Ids = int.Parse(Session["Supper"].ToString());

                    var Obj = new Delivery_Table { SupperId = Ids,Timeing=TxtDate.Text, Kind = int.Parse(DrpChoice.SelectedItem.Value),Price=int.Parse(TxtPrice.Text) };
                    db.Delivery_Table.Add(Obj);
                    db.SaveChanges();
                    if (Obj != null)
                    {

                        Literal_Message.Text = Resource1.Operation_Successed;
                        RadToolTip_Message.Text = "<div class='boxfgfg' style='left:22%;display:block'><div class='clear'></div><div><center>" + Resource1.Operation_Successed + "</center></div></div>";
                    }

                    else
                    {
                        Literal_Message.Text = Resource1.Operation_Failed;
                        RadToolTip_Message.Text = "<div class='boxfgfg' style='left:22%;display:block'><div class='clear'></div><div><center>" + Resource1.Operation_Failed + "</center></div></div>";

                    }
                }
                else
                {
                    int Id = int.Parse(hi_Id.Value);

                    Delivery_Table Obj = (from c in db.Delivery_Table where c.DeliveryId == Id select c).FirstOrDefault();
                    Obj.Kind = int.Parse(DrpChoice.SelectedItem.Value);
                    Obj.Price = int.Parse(TxtPrice.Text);
                    Obj.Timeing = TxtDate.Text;
                    db.SaveChanges();

                    Literal_Message.Text = Resource1.Operation_Successed;
                    RadToolTip_Message.Text = "<div class='boxfgfg' style='left:22%;display:block'><div class='clear'></div><div><center>" + Resource1.Operation_Successed + "</center></div></div>";

                }
                Cancle();

            }
            catch
            {
                Literal_Message.Text = Resource1.Operation_Failed;
                RadToolTip_Message.Text = "<div class='boxfgfg' style='left:22%;display:block'><div class='clear'></div><div><center>" + Resource1.Operation_Failed + "</center></div></div>";

            }
            RadToolTip_Message.Show();

            List_Project.DataBind();
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Cancle();

        }
        void Cancle()
        {
            DrpChoice.ClearSelection();
            TxtPrice.Text = "0";
            TxtDate.Text = "";
            hi_Id.Value = "";
        }
        protected void DrpProduct_DataBound(object sender, EventArgs e)
        {
            ListItem m1 = new ListItem();
            m1.Text = "«محصول را انتخاب کنید»";
            m1.Value = "0";
            DrpChoice.Items.Insert(0, m1);
        }
        protected void ObjectDataSource_Project_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["SupperId"] = int.Parse(Session["Supper"].ToString());
            e.InputParameters["Text"] = "";
        }
    }
}