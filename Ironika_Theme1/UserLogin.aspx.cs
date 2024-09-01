using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ironika_Theme1
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login_submit_Click1(object sender, EventArgs e)
        {
            Tezol_DBEntities db = new Tezol_DBEntities();

            var Objs = db.Supper_Table.FirstOrDefault(r => r.UserName == txtEmail.Text && r.Password == TxtPass.Text);
            if (Objs != null)
            {
                Session["Supper"] = Objs.SupperId;
                switch(Objs.MenuId.Value)
                {
                    case 1:
                        Response.Redirect("Panel/SupperMarket/Dashboard.aspx");
                        break;
                    case 2:
                        Response.Redirect("Panel/Shop/Dashboard.aspx");
                        break;
                    case 3:
                        Response.Redirect("Panel/Doctor/Dashboard.aspx");
                        break;
                    case 4:
                        Response.Redirect("Panel/Advocacy/Dashboard.aspx");
                        break;
                    case 5:
                        Response.Redirect("Panel/Education/Dashboard.aspx");
                        break;
                    case 6:
                        Response.Redirect("Panel/Makeup/Dashboard.aspx");
                        break;
                    case 7:
                        Response.Redirect("Panel/Laundry/Dashboard.aspx");
                        break;
                    case 8:
                        Response.Redirect("Panel/Gold/Dashboard.aspx");
                        break;
                    case 9:
                        Response.Redirect("Panel/Car/Dashboard.aspx");
                        break;
                    case 10:
                        Response.Redirect("Panel/Digital/Dashboard.aspx");
                        break;
                    case 11:
                        Response.Redirect("Panel/Online/Dashboard.aspx");
                        break;
                    case 12:
                        Response.Redirect("Panel/Concert/Dashboard.aspx");
                        break;
                    case 13:
                        Response.Redirect("Panel/Exchange/Dashboard.aspx");
                        break;
                    case 14:
                        Response.Redirect("Panel/Handicrafts/Dashboard.aspx");
                        break;
                }
                
            }
            else
                ls_Message.Text = "نام کاربری یا کلمه عبور صحیح نمی باشد";
            txtEmail.Text = "";
            TxtPass.Text = "";
        }
    }
}