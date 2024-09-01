using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Ironika_Theme1.Panel.SupperMarket
{
    public partial class Contact : System.Web.UI.Page
    {
        const Int64 MaxTotalBytes = 150000000; // 1 MB
        Int64 totalBytes;
        Tezol_DBEntities db = new Tezol_DBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Supper"] == null)
                    Response.Redirect("../../Home");
                else
                {
                    int Ids = int.Parse(Session["Supper"].ToString());

                    Supper_Table Obj = (from c in db.Supper_Table where c.SupperId == Ids select c).FirstOrDefault();

                    TxtTitle.Text = Obj.ShopName;
                    Hi_Logo.Value = Obj.Logo;
                    TxtName.Text = Obj.Name;
                    TxtLastName.Text = Obj.LastName;
                    TxtTele.Text = Obj.Tele;
                    TxtMobile.Text = Obj.Mobile;
                    TxtEmail.Text = Obj.Email;
                    TxtInstagram.Text = Obj.instagram;
                    TxtWhatsup.Text = Obj.PostalCode;
                    TxtTelegram.Text = Obj.telegram;
                    TxtAddress.Text = Obj.Address;


                    db.SaveChanges();
                }
            }
            catch { }
        }

        protected void RadAsyncUpload_Logo_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            Label fileName = new Label();
            fileName.Text = e.File.FileName;

            if (totalBytes < MaxTotalBytes)
            {
                // Total bytes limit has not been reached, accept the file
                e.IsValid = true;
                totalBytes += e.File.ContentLength;
            }
            else
            {
                // Limit reached, discard the file
                e.IsValid = false;
            }
        }

        public void MyImage()
        {
            if (RadAsyncUpload_Logo.UploadedFiles.Count > 0)
            {
                foreach (Telerik.Web.UI.UploadedFile postedFile in RadAsyncUpload_Logo.UploadedFiles)
                {

                    if (!Object.Equals(postedFile, null))
                    {
                        if (postedFile.ContentLength > 0)
                        {
                            foreach (UploadedFile file in RadAsyncUpload_Logo.UploadedFiles)
                            {

                                string[] Text = file.GetName().Split('.');
                                string Name = Text[0] + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "." + Text[1];
                                Hi_Logo.Value = Name;
                                file.SaveAs(MapPath(@"~/Content/ImageSite/" + Name));


                            }
                        }
                        else
                            Hi_Logo.Value = "";
                    }
                    else
                        Hi_Logo.Value = "";

                }
            }
        }
        protected void submit_register_Click(object sender, EventArgs e)
        {
            try
            {
                MyImage();


                int Id = int.Parse(Session["Supper"].ToString());

                Supper_Table Obj = (from c in db.Supper_Table where c.SupperId == Id select c).FirstOrDefault();

                Obj.ShopName = TxtTitle.Text;
                Obj.Logo = Hi_Logo.Value;
                Obj.Name = TxtName.Text;
                Obj.LastName = TxtLastName.Text;
                Obj.Tele = TxtTele.Text;
                Obj.Mobile = TxtMobile.Text;
                Obj.Email = TxtEmail.Text;                
                Obj.whatsup = TxtWhatsup.Text;
                Obj.instagram = TxtInstagram.Text;
                Obj.telegram = TxtTelegram.Text;
                Obj.Address = TxtAddress.Text;


                db.SaveChanges();

                Literal_Message.Text = Resource1.Operation_Successed;
                RadToolTip_Message.Text = "<div class='boxfgfg' style='left:22%;display:block'><div class='clear'></div><div><center>" + Resource1.Operation_Successed + "</center></div></div>";


                Cancle();
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
            Cancle();
        }
        void Cancle()
        {
            TxtTitle.Text = "";
            Hi_Logo.Value = "";
            TxtName.Text = "";
            TxtLastName.Text="";
            TxtTele.Text = "";
            TxtMobile.Text = "";
            TxtWhatsup.Text = "";
            TxtTelegram.Text = "";
            TxtEmail.Text = "";
            TxtInstagram.Text = "";
            TxtAddress.Text = "";

            hi_Id.Value = "";
        }
    }
}