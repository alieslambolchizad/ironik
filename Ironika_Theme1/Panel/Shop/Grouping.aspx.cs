using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Ironika_Theme1.Panel.Shop
{
    public partial class Grouping : System.Web.UI.Page
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        const Int64 MaxTotalBytes = 150000000; // 1 MB
        Int64 totalBytes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Supper"] == null)
                Response.Redirect("../../Home");
        }

        protected void ObjectDataSource_Project_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["SupperId"] = Session["Supper"].ToString();
            e.InputParameters["Text"] = "";
        }
        protected void List_Project_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int Id = int.Parse(List_Project.SelectedValue.ToString());
                hi_Id.Value = Id.ToString();

                GroupShop_Table obj = (from k in db.GroupShop_Table where k.GroupId == Id select k).Single();
                if (obj != null)
                {
                    TxtName.Text = obj.Name;
                    hi_Logo.Value = obj.Imageurl;
                }

                else
                {
                    Cancle();
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
        public void MyImage_Image()
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
                                hi_Logo.Value = Name;
                                file.SaveAs(MapPath(@"~/Content/ImageSite/" + Name));


                            }
                        }
                        else
                            hi_Logo.Value = "";
                    }
                    else
                        hi_Logo.Value = "";

                }
            }
        }

        protected void submit_register_Click(object sender, EventArgs e)
        {
            try
            {

                MyImage_Image();
                if (hi_Id.Value == "")
                {
                    int Ids = int.Parse(Session["Supper"].ToString());

                    var Obj = new GroupShop_Table { Name = TxtName.Text,SupperId=Ids,Imageurl=hi_Logo.Value};
                    db.GroupShop_Table.Add(Obj);
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

                    GroupShop_Table Obj = (from c in db.GroupShop_Table where c.GroupId == Id select c).FirstOrDefault();

                    Obj.Name = TxtName.Text;
                    Obj.Imageurl = hi_Logo.Value;

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
            hi_Logo.Value = "";
            
            hi_Id.Value = "";
        }


      
       
    }
}

