using Ironika_Theme1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ironika_Theme1.Panel.SupperMarket
{
    public partial class Comments : System.Web.UI.Page
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

                Review_Table obj = (from k in db.Review_Table where k.ReviewId == Id select k).Single();
                if (obj != null)
                {
                    ChState.Checked = obj.State.Value;
                    RadEditor_Description.Content = obj.Description;
                }

                else
                {
                    Cancle();
                }
            }
            catch { }
        }

        public string NumberFormat_Register(int UserId)
        {
            try
            {
                var Objs = db.User_Table.FirstOrDefault(r => r.UserId == UserId);
                if (Objs != null)
                    return Objs.Name+" "+Objs.Lastname;
                else
                    return "";
            }
            catch { return ""; }
        }
        public string NumberFormat_Product(int ProductId)
        {
            try
            {
                var Objs = db.Product_Table.FirstOrDefault(r => r.ProductId == ProductId);
                if (Objs != null)
                    return Objs.Name;
                else
                    return "";
            }
            catch { return ""; }
        }
        public string NumberFormat_Date(DateTime DateSales)
        {
            return Date_Manager.ConvertDate(DateSales);
        }
        protected void submit_register_Click(object sender, EventArgs e)
        {
            try
            {

                if (hi_Id.Value == "")
                {
                    Literal_Message.Text = Resource1.Record_Failed;
                    RadToolTip_Message.Text = "<div class='boxfgfg' style='left:22%;display:block'><div class='clear'></div><div><center>" + Resource1.Record_Failed + "</center></div></div>";
                }
                else
                {
                    int Id = int.Parse(hi_Id.Value);

                    Review_Table Obj = (from c in db.Review_Table where c.ReviewId == Id select c).FirstOrDefault();

                    Obj.State = ChState.Checked;                

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
            ChState.Checked = false;
            RadEditor_Description.Content = "";
            hi_Id.Value = "";
        }

        protected void ObjectDataSource_Project_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["SupperId"] = Session["Supper"].ToString();
            e.InputParameters["Text"] = "";
        }
    }
}