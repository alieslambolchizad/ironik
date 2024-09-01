using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ironika_Theme1.Panel.Shop
{
    public partial class ChangePass : System.Web.UI.Page
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Supper"] == null)
                Response.Redirect("../../Home");
        }
        protected void submit_register_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Supper"] != null)
                {
                    int Id = int.Parse(Session["Supper"].ToString());

                    Supper_Table Obj = (from c in db.Supper_Table where c.SupperId == Id select c).FirstOrDefault();
                    if (Obj.Password == TxtOldPass.Text)
                    {
                        Obj.Password = TxtNewpass.Text;


                        db.SaveChanges();

                        Literal_Message.Text = Resource1.Operation_Successed;
                        RadToolTip_Message.Text = "<div class='boxfgfg' style='left:22%;display:block'><div class='clear'></div><div><center>" + Resource1.Operation_Successed + "</center></div></div>";

                    }
                    else
                    {
                        Literal_Message.Text = Resource1.OldPass_NotCorrect;
                        RadToolTip_Message.Text = "<div class='boxfgfg' style='left:22%;display:block'><div class='clear'></div><div><center>کلمه عبور قبلی صحیح نیست</center></div></div>";

                    }
                }
                else
                    Response.Redirect("../../Home");
            }
            catch
            {
                Literal_Message.Text = Resource1.Operation_Failed;
                RadToolTip_Message.Text = "<div class='boxfgfg' style='left:22%;display:block'><div class='clear'></div><div><center>" + Resource1.Operation_Failed + "</center></div></div>";

            }
            RadToolTip_Message.Show();


        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            hi_Id.Value = "";

            TxtOldPass.Text = "";
            TxtNewpass.Text = "";
            TxtDuplicatepass.Text = "";


        }
    }
}