using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ironika_Theme1.Panel.Shop
{
    public partial class About : System.Web.UI.Page
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

                Content_Table obj = (from k in db.Content_Table where k.ContentId == Id select k).Single();
                if (obj != null)
                {
                    TxtName.Text = obj.Title;
                    RadEditor_Description.Content = obj.Description;
                }

                else
                {
                    Cancle();
                }
            }
            catch { }
        }



        protected void submit_register_Click(object sender, EventArgs e)
        {
            try
            {

                if (hi_Id.Value == "")
                {
                    int Ids = int.Parse(Session["Supper"].ToString());

                    var Obj = new Content_Table {SupperId=Ids, Title = TxtName.Text, Description = RadEditor_Description.Content, Kind = 1 };
                    db.Content_Table.Add(Obj);
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

                    Content_Table Obj = (from c in db.Content_Table where c.ContentId == Id select c).FirstOrDefault();

                    Obj.Title = TxtName.Text;
                    Obj.Description = RadEditor_Description.Content;

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
            TxtName.Text = "";
            RadEditor_Description.Content = "";
            hi_Id.Value = "";
        }

        protected void ObjectDataSource_Project_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

            e.InputParameters["SupperId"] = int.Parse(Session["Supper"].ToString());
            e.InputParameters["Kind"] = "1";
            e.InputParameters["Text"] = "";
        }
    }
}