using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Ironika_Theme1.Panel.Shop
{
    public partial class Product : System.Web.UI.Page
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        const Int64 MaxTotalBytes = 150000000; // 1 MB
        Int64 totalBytes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Supper"] == null)
                Response.Redirect("../../Home");
        }



        protected void DrpGroup_DataBound(object sender, EventArgs e)
        {
            ListItem m1 = new ListItem();
            m1.Text = "«گروه محصول را انتخاب کنید»";
            m1.Value = "0";
            DrpGroup.Items.Insert(0, m1);
        }


        public string NumberFormat_Group(int GroupId)
        {
            try
            {
                var Objs = db.GroupShop_Table.FirstOrDefault(r => r.GroupId == GroupId);
                if (Objs != null)
                {
                    return Objs.Name;
                }
                else
                    return "";
            }
            catch { return ""; }
        }


        public string NumberFormat(int Text)
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

                ProductShop_Table obj = (from k in db.ProductShop_Table where k.ProductId == Id select k).Single();
                if (obj != null)
                {

                    DrpGroup.ClearSelection();

                    for (int i = 0; i < DrpGroup.Items.Count; i++)
                    {
                        if (DrpGroup.Items[i].Value == obj.GroupId.Value.ToString())
                        {
                            DrpGroup.Items[i].Selected = true;

                            break;
                        }
                    }
                    TxtName.Text = obj.Name;
                    DrpRating.ClearSelection();
                    DrpRating.Items[obj.Rating.Value].Selected = true;
                    hi_Logo.Value = obj.Imageurl;
                    hi_Logos.Value = obj.Images;
                    TxtPrice.Text = obj.Price.Value.ToString();
                    RadEditor_Attribute.Content = obj.attributes;
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
                MyImage_Image(); MyImage_Images();
                if (hi_Id.Value == "")
                {
                    int Ids = int.Parse(Session["Supper"].ToString());

                    var Obj = new ProductShop_Table { GroupId = int.Parse(DrpGroup.SelectedItem.Value), attributes = RadEditor_Attribute.Content, Price = int.Parse(TxtPrice.Text), Description = RadEditor_Description.Content, Images = hi_Logos.Value, Imageurl = hi_Logo.Value, Name = TxtName.Text, Rating = int.Parse(DrpRating.SelectedItem.Value) };
                    db.ProductShop_Table.Add(Obj);
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

                    ProductShop_Table Obj = (from c in db.ProductShop_Table where c.ProductId == Id select c).FirstOrDefault();

                    Obj.GroupId = int.Parse(DrpGroup.SelectedItem.Value);
                    Obj.Price = int.Parse(TxtPrice.Text);
                    Obj.Name = TxtName.Text;
                    Obj.Imageurl = hi_Logo.Value;
                    Obj.Images = hi_Logos.Value;
                    Obj.Description = RadEditor_Description.Content;
                    Obj.attributes = RadEditor_Attribute.Content;
                    Obj.Rating = int.Parse(DrpRating.SelectedItem.Value);

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
            DrpGroup.ClearSelection();
            DrpRating.ClearSelection();
            TxtPrice.Text = "0";
            TxtName.Text = "";
            hi_Logo.Value = "";
            hi_Logos.Value = "";
            RadEditor_Attribute.Content = "";
            RadEditor_Description.Content = "";
            hi_Id.Value = "";
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
        protected void RadAsyncUpload_Logos_FileUploaded(object sender, FileUploadedEventArgs e)
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
        public void MyImage_Images()
        {
            if (RadAsyncUpload_Logos.UploadedFiles.Count > 0)
            {
                foreach (Telerik.Web.UI.UploadedFile postedFile in RadAsyncUpload_Logos.UploadedFiles)
                {

                    if (!Object.Equals(postedFile, null))
                    {
                        if (postedFile.ContentLength > 0)
                        {
                            foreach (UploadedFile file in RadAsyncUpload_Logos.UploadedFiles)
                            {

                                string[] Text = file.GetName().Split('.');
                                string Name = Text[0] + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "." + Text[1];
                                hi_Logos.Value = Name;
                                file.SaveAs(MapPath(@"~/Content/ImageSite/" + Name));


                            }
                        }
                        else
                            hi_Logos.Value = "";
                    }
                    else
                        hi_Logos.Value = "";

                }
            }
        }
        protected void ObjectDataSource_Group_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["SupperId"] = Session["Supper"].ToString();
        }

    }
}