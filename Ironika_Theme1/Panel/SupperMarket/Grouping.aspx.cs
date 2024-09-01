using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ironika_Theme1.Panel.SupperMarket
{
    public partial class Grouping : System.Web.UI.Page
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Supper"] == null)
                Response.Redirect("../../Home");
        }

        protected void DrpBig_DataBound(object sender, EventArgs e)
        {
            ListItem m1 = new ListItem();
            m1.Text = "«گروه اصلی را انتخاب کنید»";
            m1.Value = "0";
            DrpBig.Items.Insert(0, m1);
        }

        protected void DrpParent_DataBound(object sender, EventArgs e)
        {
            ListItem m1 = new ListItem();
            m1.Text = "«گروه میانی را انتخاب کنید»";
            m1.Value = "0";
            DrpParent.Items.Insert(0, m1);
        }

        protected void DrpBig_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrpParent.DataBind();
        }

        protected void DrpParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrpGroup.DataBind();
        }

        protected void ObjectDataSource_Parent_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["Parent"] = DrpBig.SelectedItem.Value;
        }

        protected void ObjectDataSource_Group_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["Parent"] = DrpParent.SelectedItem.Value;
        }

        public string NumberFormat_Big(int GroupId)
        {
            try
            {
                var Objs = db.Group_Table.FirstOrDefault(r => r.GroupId == GroupId);
                if (Objs != null)
                {
                    int IdsParent = Objs.Parent.Value;

                    var ObjsParent = db.Group_Table.FirstOrDefault(r => r.GroupId == IdsParent);
                    if (ObjsParent != null)
                    {
                        int IdsBig = ObjsParent.Parent.Value;

                        var ObjsBig = db.Group_Table.FirstOrDefault(r => r.GroupId == IdsBig);
                        if (ObjsBig != null)
                            return ObjsBig.Name;
                        else
                            return "";
                    }
                    else
                        return "";
                }
                else
                    return "";
            }
            catch { return ""; }
        }
        public string NumberFormat_Parent(int GroupId)
        {
            try
            {
                var Objs = db.Group_Table.FirstOrDefault(r => r.GroupId == GroupId);
                if (Objs != null)
                {
                    int IdsParent = Objs.Parent.Value;

                    var ObjsParent = db.Group_Table.FirstOrDefault(r => r.GroupId == IdsParent);
                    if (ObjsParent != null)
                        return ObjsParent.Name;
                    else
                        return "";
                }
                else
                    return "";
            }
            catch { return ""; }
        }
        public string NumberFormat_Group(int GroupId)
        {
            try
            {
                var Objs = db.Group_Table.FirstOrDefault(r => r.GroupId == GroupId);
                if (Objs != null)
                  return Objs.Name;
                else
                    return "";
            }
            catch { return ""; }
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

                OwenerGroup_Table obj = (from k in db.OwenerGroup_Table where k.OwnerGroupId == Id select k).Single();
                if (obj != null)
                {
                    int Parant = 0;int Big = 0;
                    int GroupId = obj.GroupId.Value;

                    

                    var ObjGroup = db.Group_Table.FirstOrDefault(r=>r.GroupId== GroupId);
                    if (ObjGroup != null)
                    {
                        Parant = ObjGroup.Parent.Value;
                        
                        var ObjParent = db.Group_Table.FirstOrDefault(r=>r.GroupId== Parant);
                        if(ObjParent!=null)
                        {
                            Big = ObjParent.Parent.Value;
                            DrpBig.ClearSelection();
                            for (int i = 0; i <DrpBig.Items.Count; i++)
                            {
                                if (DrpBig.Items[i].Value == Big.ToString())
                                {
                                    DrpBig.Items[i].Selected = true;
                                    DrpParent.DataBind();
                                    break;
                                }
                            }
                        }
                        DrpParent.ClearSelection();
                        for (int i = 0; i < DrpParent.Items.Count; i++)
                        {
                            if (DrpParent.Items[i].Value == Parant.ToString())
                            {
                                DrpParent.Items[i].Selected = true;
                                DrpGroup.DataBind();
                                break;
                            }
                        }
                        DrpGroup.ClearSelection();
                        for (int i = 0; i < DrpGroup.Items.Count; i++)
                        {
                            if (DrpGroup.Items[i].Value == GroupId.ToString())
                            {
                                DrpGroup.Items[i].Selected = true;
                                break;
                            }
                        }
                    }

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

                    var Obj = new OwenerGroup_Table { GroupId = int.Parse(DrpGroup.SelectedItem.Value),SupperId=Ids};
                    db.OwenerGroup_Table.Add(Obj);
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

                    OwenerGroup_Table Obj = (from c in db.OwenerGroup_Table where c.OwnerGroupId == Id select c).FirstOrDefault();

                    Obj.GroupId = int.Parse(DrpGroup.SelectedItem.Value);                   

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
           
            DrpBig.ClearSelection();           
            DrpParent.ClearSelection();           
            DrpGroup.ClearSelection();
            
            hi_Id.Value = "";
        }


      
        protected void DrpGroup_DataBound(object sender, EventArgs e)
        {
            ListItem m1 = new ListItem();
            m1.Text = "«گروه محصول را انتخاب کنید»";
            m1.Value = "0";
            DrpGroup.Items.Insert(0, m1);
        }
    }
}

