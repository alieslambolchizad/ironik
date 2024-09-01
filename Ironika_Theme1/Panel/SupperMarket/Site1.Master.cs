using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ironika_Theme1.Panel.SupperMarket
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Supper"] == null)
                Response.Redirect("../../Home");
            try
            {
                int Ids = db.Contact_Table.Max(r=>r.ContactId);
                var Objs = db.Contact_Table.FirstOrDefault(r=>r.ContactId==Ids);
                if (Objs != null)
                    ImgLogo.Src = "../../Content/ImageSite/" + Objs.Logo;
                else
                    ImgLogo.Src = "";
            }
            catch { }
        }
    }
}