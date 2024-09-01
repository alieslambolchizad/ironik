using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ironika_Theme1.Panel.SupperMarket
{
    public partial class Product : System.Web.UI.Page
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Supper"] == null)
                Response.Redirect("../../Home");
        }

        protected void DrpProduct_DataBound(object sender, EventArgs e)
        {
            ListItem m1 = new ListItem();
            m1.Text = "«محصول را انتخاب کنید»";
            m1.Value = "0";
            DrpProduct.Items.Insert(0, m1);
        }

        protected void DrpGroup_DataBound(object sender, EventArgs e)
        {
            ListItem m1 = new ListItem();
            m1.Text = "«گروه محصول را انتخاب کنید»";
            m1.Value = "0";
            DrpGroup.Items.Insert(0, m1);
        }

        protected void DrpGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrpProduct.DataBind();
        }
        public string NumberFormat_Group(int ProductId)
        {
            try
            {
                var Objs = db.Product_Table.FirstOrDefault(r => r.ProductId == ProductId);
                if (Objs != null)
                {
                    return Objs.Group_Table.Name;
                }
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
                {
                    return Objs.Name;
                }
                else
                    return "";
            }
            catch { return ""; }
        }
        public string NumberFormat_Image(int ProductId)
        {
            try
            {
                var Objs = db.Product_Table.FirstOrDefault(r => r.ProductId == ProductId);
                if (Objs != null)
                {
                    return "<img style='width:60px;height:40px' Src=../../Content/ImageSite/" + Objs.Imageurl + " ></img>";
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

                OwnerProduct_Table obj = (from k in db.OwnerProduct_Table where k.OwnerProductId == Id select k).Single();
                if (obj != null)
                {

                    DrpGroup.ClearSelection();
                    DrpProduct.ClearSelection();


                    DrpGroup.ClearSelection();
                    for (int i = 0; i < DrpGroup.Items.Count; i++)
                    {
                        if (DrpGroup.Items[i].Value == obj.Product_Table.GroupId.Value.ToString())
                        {
                            DrpGroup.Items[i].Selected = true;
                            DrpProduct.DataBind();
                            break;
                        }
                    }

                    DrpProduct.ClearSelection();
                    for (int i = 0; i < DrpProduct.Items.Count; i++)
                    {
                        if (DrpProduct.Items[i].Value == obj.ProductId.Value.ToString())
                        {
                            DrpProduct.Items[i].Selected = true;
                            break;
                        }
                    }

                    TxtPrice.Text = obj.Price.Value.ToString();
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

                    var Obj = new OwnerProduct_Table { ProductId = int.Parse(DrpProduct.SelectedItem.Value), SupperId = Ids, Price = int.Parse(TxtPrice.Text) };
                    db.OwnerProduct_Table.Add(Obj);
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

                    OwnerProduct_Table Obj = (from c in db.OwnerProduct_Table where c.OwnerProductId == Id select c).FirstOrDefault();

                    Obj.ProductId = int.Parse(DrpProduct.SelectedItem.Value);
                    Obj.Price = int.Parse(TxtPrice.Text);

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
            DrpProduct.ClearSelection();
            TxtPrice.Text = "0";
            hi_Id.Value = "";
        }

        protected void ObjectDataSource_Group_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["SupperId"] = Session["Supper"].ToString();
        }

       

        protected void ObjectDataSource_Producct_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["GroupId"] = DrpGroup.SelectedItem.Value;
        }

     
    }
}