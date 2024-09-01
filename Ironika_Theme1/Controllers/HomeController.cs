using Ironika_Theme1.Models;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
//using static Ironika_Theme1.Models;
//using PagedList;
//using Ironika_Theme1.Models;


namespace Ironika_Theme1.Controllers
{

    public class HomeController : Controller
    {
        Tezol_DBEntities db = new Tezol_DBEntities();

        List<GroupShop> lstBig = new List<GroupShop>();
        List<Group_Table> lstParent = new List<Group_Table>();

        List<Product_Table> lstProduct = new List<Product_Table>();
        List<ClientOrder_Manager> BasketProduct = new List<ClientOrder_Manager>();

        static List<GroupShop> lstBig_Menu = new List<GroupShop>();
        static List<GroupShop> lstParent_Menu = new List<GroupShop>();
        static List<GroupShop> lstChild_Menu = new List<GroupShop>();

        static int GroupId = 0;
        static int BrandsId = 0;
        static string GroupName = "";
        static string GroupNamePage = "";
        static string BrandName = "";
        static string CountAll = "";
        public const int RecordsPerPage = 20;
        public List<Product> ProjectData;
        static List<Product> list_Pro = new List<Product>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Privacy()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Terms()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Faq()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Signin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FrmSignin(Main mymodel)
        {
            try
            {

                var Obj = db.User_Table.FirstOrDefault(r => r.Username == mymodel.ValidationRegister.UserName && r.Password == mymodel.ValidationRegister.Password);
                if (Obj != null)
                {
                    Session["UserSite"] = Obj.UserId;
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    TempData["Status"] = "نام کاربری یا کلمه عبور مجاز نمی باشد";
                    return RedirectToAction("Signin", "Home");
                }
            }
            catch
            {
                TempData["Status"] = "عملیات با شکست انجام شد. با مدیر سایت تماس بگیرید";
                return RedirectToAction("Signin", "Home");
            }
        }
        public ActionResult Signup()
        {
            ViewBag.Message = "Your contact page.";

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FrmSignup(Main mymodel)
        {

            try
            {
                var Obj = db.User_Table.FirstOrDefault(r => r.Email == mymodel.ValidationRegister.Email);
                if (Obj == null)
                {

                    Obj = new User_Table { Name = mymodel.ValidationRegister.Name, Lastname = mymodel.ValidationRegister.LastName, Email = mymodel.ValidationRegister.Email, Password = mymodel.ValidationRegister.Password, Username = mymodel.ValidationRegister.UserName, RegisterDate = DateTime.Now };
                    db.User_Table.Add(Obj);
                    db.SaveChanges();
                    if (Obj != null)
                    {


                        try
                        {
                            string ur = System.Web.HttpContext.Current.Server.MapPath("~/Views/Shared/EMAIL.cshtml");
                            string file = System.IO.File.ReadAllText(ur);

                            EmailModel model = new EmailModel()
                            {
                                RecieverEmail = mymodel.ValidationRegister.Email,
                                Subject = "خوش آمدگویی",
                                Text = mymodel.ValidationRegister.Name + " " + mymodel.ValidationRegister.LastName + " به جمع کاربران سایت خوش آمدید <br>  با احترام نام کاربری و کلمه عبور به شرح زیر است : <br>نام کاربری  : " + mymodel.ValidationRegister.UserName + "<br>کلمه عبور: " + mymodel.ValidationRegister.Password,

                                FullName = mymodel.ValidationRegister.Name,
                                Email = "No_Replay@ironika.ir",
                                EmailUser = mymodel.ValidationRegister.Email,
                            };
                            string result = Razor.Parse(file, model);

                            MailMessage message = new MailMessage("No_Replay@ironika.ir", model.RecieverEmail, model.Subject, result);
                            message.IsBodyHtml = true;
                            message.BodyEncoding = System.Text.Encoding.UTF8;
                            message.SubjectEncoding = System.Text.Encoding.UTF8;
                            message.HeadersEncoding = System.Text.Encoding.UTF8;

                            using (SmtpClient client = new SmtpClient("mail.ironika.ir", 25))
                            {
                                //client.EnableSsl = true;

                                client.UseDefaultCredentials = false;
                                client.Credentials = new NetworkCredential("No_Replay@ironika.ir", "Ew0_v0w2");

                                client.Send(message);

                            }
                        }
                        catch (Exception ex)
                        {
                        }
                        Session["UserSite"] = Obj.UserId;
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        TempData["StatusFailed"] = "عملیات با شکست انجام شد. با مدیر سایت تماس بگیرید";
                        return RedirectToAction("signup", "Home");
                    }
                }
                else
                {
                    TempData["StatusFailed"] = "آدرس ایمیل تکراری است";
                    return RedirectToAction("signup", "Home");
                }
            }
            catch
            {
                TempData["StatusFailed"] = "عملیات با شکست انجام شد. با مدیر سایت تماس بگیرید";
                return RedirectToAction("signup", "Home");
            }
        }
        public ActionResult Forget()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FrmForget(Main mymodel)
        {
            try
            {
                var Obj = db.User_Table.FirstOrDefault(r => r.Email == mymodel.ValidationRegister.Email);
                if (Obj != null)
                {
                    string ur = System.Web.HttpContext.Current.Server.MapPath("~/Views/Shared/EMAIL.cshtml");
                    string file = System.IO.File.ReadAllText(ur);

                    EmailModel model = new EmailModel()
                    {
                        RecieverEmail = mymodel.ValidationRegister.Email,
                        Subject = "بازیابی کلمه عبور",
                        Text = Obj.Name + " ، کلمه عبور بازیابی شده شما " + Obj.Password,
                        Password = Obj.Password,
                        FullName = Obj.Name + " " + Obj.Lastname,
                        Email = "No_Replay@ironika.ir",
                        EmailUser = mymodel.ValidationRegister.Email,
                    };
                    string result = Razor.Parse(file, model);

                    MailMessage message = new MailMessage("No_Replay@ironika.ir", model.RecieverEmail, model.Subject, result);
                    message.IsBodyHtml = true;
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    message.HeadersEncoding = System.Text.Encoding.UTF8;

                    using (SmtpClient client = new SmtpClient("mail.ironika.ir", 25))
                    {
                        //client.EnableSsl = true;

                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("No_Replay@ironika.ir", "Ew0_v0w2");

                        client.Send(message);

                    }

                    TempData["StatusFailed"] = "ایمیل با موفقیت ارسال شد . لطفا بررسی کنید";
                    return RedirectToAction("Forget", "Home");
                }
                else
                {
                    TempData["StatusFailed"] = "آدرس ایمیل یافت نشد";
                    return RedirectToAction("Forget", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["StatusFailed"] = "عملیات با شکست انجام شد. با مدیر سایت تماس بگیرید";
                return RedirectToAction("Forget", "Home");
            }

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FrmContact(Main mymodel)
        {
            try
            {
                var Obj = new People_Table { Name = mymodel.ValidationPeople.Name, Email = mymodel.ValidationPeople.Email, Tele = mymodel.ValidationPeople.Tele, Message = mymodel.ValidationPeople.Message, DareRequestLa = DateTime.Now };
                db.People_Table.Add(Obj);
                db.SaveChanges();
                if (Obj != null)
                {
                    TempData["StatusFailed"] = "فرم با موفقیت ثبت شد";
                    return RedirectToAction("Contact", "Home");

                }
                else
                {
                    TempData["StatusFailed"] = "عملیات با شکست انجام شد. با مدیر سایت تماس بگیرید";
                    return RedirectToAction("Contact", "Home");
                }
            }

            catch
            {
                TempData["StatusFailed"] = "عملیات با شکست انجام شد. با مدیر سایت تماس بگیرید";
                return RedirectToAction("Contact", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FrmNewsLetter(Main mymodel)
        {
            try
            {
                var Obj = new People_Table { Email = mymodel.ValidationPeople.Email, DareRequestLa = DateTime.Now };
                db.People_Table.Add(Obj);
                db.SaveChanges();
                if (Obj != null)
                {
                    TempData["StatusFailed"] = "فرم با موفقیت ثبت شد";
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    TempData["StatusFailed"] = "عملیات با شکست انجام شد. با مدیر سایت تماس بگیرید";
                    return RedirectToAction("Index", "Home");
                }
            }

            catch
            {
                TempData["StatusFailed"] = "عملیات با شکست انجام شد. با مدیر سایت تماس بگیرید";
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Listing(string Id)
        {
            if (Id != null)
            {
                try
                {
                    string GroupName = Id.Trim().Replace("-", " ");
                    GroupNamePage = GroupName;
                    var ObjsGroup = db.Group_Table.FirstOrDefault(r => r.Name == GroupName);
                    if (ObjsGroup != null)
                    {

                        var Objs = db.Group_Table.FirstOrDefault(r => r.GroupId == ObjsGroup.GroupId);
                        if (Objs.Parent != null)
                        {
                            var ObjsParent = db.Group_Table.FirstOrDefault(r => r.GroupId == Objs.Parent);
                            if (ObjsParent != null)
                            {
                                if (ObjsParent.Parent != null)
                                {
                                    list_Pro = db.Product_Table.Where(r => r.GroupId == ObjsGroup.GroupId).Select(a => new Product { ProductId = a.ProductId, Name = a.Name, ImageUrl = a.Imageurl, PriceNew = a.Price.Value, PriceOld = a.Price.Value, Rating = a.Rating.Value }).OrderByDescending(r => r.ProductId).ToList();

                                }
                                else
                                {
                                    list_Pro = db.Product_Table.Where(r => r.Group_Table.Parent == Objs.GroupId).Select(a => new Product { ProductId = a.ProductId, Name = a.Name, ImageUrl = a.Imageurl, PriceNew = a.Price.Value, PriceOld = a.Price.Value, Rating = a.Rating.Value }).OrderByDescending(r => r.ProductId).ToList();
                                }
                            }
                        }
                        else
                        {
                            List<Group_Table> lstBig = db.Group_Table.Where(r => r.Parent == ObjsGroup.GroupId).ToList();
                            if (lstBig.Count > 0)
                            {
                                foreach (var item in lstBig)
                                {
                                    lstParent = db.Group_Table.Where(r => r.Parent == item.GroupId).ToList();
                                    if (lstParent.Count > 0)
                                    {
                                        foreach (var items in lstParent)
                                        {
                                            list_Pro.AddRange(db.Product_Table.Where(r => r.GroupId == items.GroupId).Select(a => new Product { ProductId = a.ProductId, Name = a.Name, ImageUrl = a.Imageurl, PriceNew = a.Price.Value, PriceOld = a.Price.Value, Rating = a.Rating.Value }).OrderByDescending(r => r.ProductId).ToList());
                                        }
                                    }
                                    else
                                    {
                                        list_Pro.AddRange(db.Product_Table.Where(r => r.GroupId == item.GroupId).Select(a => new Product { ProductId = a.ProductId, Name = a.Name, ImageUrl = a.Imageurl, PriceNew = a.Price.Value, PriceOld = a.Price.Value, Rating = a.Rating.Value }).OrderByDescending(r => r.ProductId).ToList());
                                    }
                                }
                            }
                            else
                            {
                                list_Pro.AddRange(db.Product_Table.Where(r => r.GroupId == ObjsGroup.GroupId).Select(a => new Product { ProductId = a.ProductId, Name = a.Name, ImageUrl = a.Imageurl, PriceNew = a.Price.Value, PriceOld = a.Price.Value, Rating = a.Rating.Value }).OrderByDescending(r => r.ProductId).ToList());
                            }
                        }
                    }
                    else
                    {
                        var ObjMenu = db.Menu_Table.FirstOrDefault(r => r.Title == GroupName);
                        int Kind = 0;
                        if (ObjMenu != null)
                        {
                            Kind = ObjMenu.Kind.Value;
                        }
                        list_Pro = db.Product_Table.Where(r => r.Kind == Kind).Select(a => new Product { ProductId = a.ProductId, Name = a.Name, ImageUrl = a.Imageurl, PriceNew = a.Price.Value, PriceOld = a.Price.Value, Rating = a.Rating.Value }).OrderByDescending(r => r.ProductId).ToList();

                    }

                    return RedirectToAction("GetProjects");
                }
                catch (Exception ex)
                { }


            }

            return View();
        }
        public ActionResult Details(string Id)
        {
            ViewBag.Message = "Your application description page.";
            try
            {
                if (Id != null)
                {
                    string[] Text = Id.Split('_');
                    string SupperName = Text[0].Trim().Replace("-", " ");
                    string ProductName = Text[1].Trim().Replace("-", " ");
                    var Objs = db.OwnerProduct_Table.FirstOrDefault(r => r.Supper_Table.ShopName == SupperName && r.Product_Table.Name == ProductName);
                    ViewBag.Name = Objs.OwnerProductId;
                }
                else
                {
                    ViewBag.Name = "0";
                }
            }
            catch { ViewBag.Name = "0"; }


            return View();
        }
        public ActionResult Comment(string Id)
        {
            try
            {
                ViewBag.Name = Id.Trim().Replace("-", " ");
                if (Session["UserSite"] == null)
                {
                    return RedirectToAction("Signin", "Home");
                }
                else
                {
                    string[] Text = Id.Split('_');
                    string SupperName = Text[0].Trim().Replace("-", " ");
                    string ProductName = Text[1].Trim().Replace("-", " ");
                    var Objs = db.OwnerProduct_Table.FirstOrDefault(r => r.Supper_Table.ShopName == SupperName && r.Product_Table.Name == ProductName);
                    ViewBag.Name = Objs.OwnerProductId;
                    ViewBag.Rating = new SelectList(db.Rating_Table.OrderBy(r => r.Title), "RatingId", "Title");
                    return View();
                }
            }
            catch { ViewBag.Name = "0"; return View(); }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FrmNewComment(Main mymodel, int ProductId = 0)
        {
            try
            {
                var Obj = new Review_Table { Rating = mymodel.ValidationReview.RatingId, UserId = int.Parse(Session["UserSite"].ToString()), Description = mymodel.ValidationReview.Message, ProductId = ProductId, RegisterDate = DateTime.Now };
                db.Review_Table.Add(Obj);
                db.SaveChanges();
                if (Obj != null)
                {
                    TempData["StatusFailed"] = "فرم با موفقیت ثبت شد";


                }
                else
                {
                    TempData["StatusFailed"] = "عملیات با شکست انجام شد. با مدیر سایت تماس بگیرید";

                }
            }

            catch
            {
                TempData["StatusFailed"] = "عملیات با شکست انجام شد. با مدیر سایت تماس بگیرید";

            }
            return RedirectToAction("Comment", "Home");

        }
        public ActionResult GetProjects(int? pageNum)
        {
            ViewBag.GroupId = GroupId;
            ViewBag.list_Pro = list_Pro;



            List<Product> tempList = new List<Product>();
            foreach (var items in list_Pro)
            {
                tempList.Add(new Product()
                {
                    ProductId = items.ProductId,
                    Name = items.Name,
                    ImageUrl = items.ImageUrl,
                    Rating = items.Rating,
                    PriceNew = items.PriceNew,
                    PriceOld = items.PriceOld,
                });
            }

            ViewBag.All = tempList;

            //ViewBag.Name = GroupName;
            ViewBag.Name = GroupNamePage;
            ViewBag.ParentCount = CountAll;


            pageNum = pageNum ?? 0;
            ViewBag.IsEndOfRecords = false;
            if (Request.IsAjaxRequest())
            {
                var projects = GetRecordsForPage(pageNum.Value);
                ViewBag.IsEndOfRecords = (projects.Any());
                return PartialView("_ProjectData", projects);
            }
            else
            {

                ProjectData = ViewBag.All;

                ViewBag.TotalNumberProjects = ProjectData.Count;
                ViewBag.Projects = GetRecordsForPage(pageNum.Value);

                return View("Listing");
            }
        }
        public List<Product> GetRecordsForPage(int pageNum)
        {

            ProjectData = ViewBag.All;

            int from = (pageNum * RecordsPerPage);

            var tempList = (from rec in ProjectData
                            select rec).Skip(from).Take(20).ToList<Product>();
            ViewBag.All = tempList;
            return tempList;
        }
        public ActionResult ShopList(string Id)
        {
            if (Id != null)
            {
                try
                {
                    ViewBag.Name = Id.Trim().Replace("-", " ");
                }
                catch { }
            }
            return View();
        }
        public ActionResult LikeShopList()
        {
            return View();
        }
        public ActionResult LikeProductList()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FrmLikeShop(Main mymodel, int SupperId = 0)
        {
            try
            {
                if (Session["UserSite"] != null)
                {
                    int UserId = int.Parse(Session["UserSite"].ToString());
                    var Objs = db.Like_Table.FirstOrDefault(r => r.UserId == UserId && r.SupperId == SupperId && r.State == true);
                    if (Objs == null)
                    {
                        var Obj = new Like_Table { SupperId = SupperId, State = true, UserId = UserId };
                        db.Like_Table.Add(Obj);
                        db.SaveChanges();
                    }

                    return RedirectToAction("LikeShopList", "Home");
                }
                else
                {
                    return RedirectToAction("Signin", "Home");
                }
            }
            catch
            {
                return RedirectToAction("LikeShopList", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FrmLikeProduct(Main mymodel, int ProductId = 0)
        {
            try
            {
                if (Session["UserSite"] != null)
                {
                    int UserId = int.Parse(Session["UserSite"].ToString());
                    var Objs = db.Like_Table.FirstOrDefault(r => r.UserId == UserId && r.ProductId == ProductId && r.State == false);
                    if (Objs == null)
                    {
                        var Obj = new Like_Table { ProductId = ProductId, State = false, UserId = UserId };
                        db.Like_Table.Add(Obj);
                        db.SaveChanges();
                    }

                    return RedirectToAction("LikeProductList", "Home");
                }
                else
                {
                    return RedirectToAction("Signin", "Home");
                }
            }
            catch
            {
                return RedirectToAction("LikeProductList", "Home");
            }
        }
        public ActionResult Basket()
        {
            Session["AllNumber1"] = "0";
            return View();
        }
        public static String NumberFormat(string Text)
        {
            try
            {
                int Length = Text.Length;
                string MyText = "";
                int i = Length - 3;
                int j = 3;
                while (Length > 3)
                {
                    MyText = Text.Substring(i, j) + "." + MyText;
                    i = i - 3;
                    Length = Length - 3;
                }
                if (Length > 0)
                    MyText = Text.Substring(0, Length) + "." + MyText;
                MyText = MyText.Substring(0, MyText.Length - 1);
                return MyText;
            }
            catch { return ""; }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sales(int TempId = 0, string txtCount = "")
        {

            int NumberId = 0;
            if (txtCount != "")
            {
                NumberId = int.Parse(txtCount);
            }
            List<ClientOrder_Manager> model = null;
            List<ClientOrder_Manager> modelEdit = null;
            try
            {
                model = (List<ClientOrder_Manager>)Session["MyClientOrder"];
            }
            catch { }
            Int64 AllNumber1 = 0; Int64 AllNumber2 = 0;
            try
            {
                if (Session["AllNumber1"] != null)
                {
                    AllNumber1 = Int64.Parse(Session["AllNumber1"].ToString());
                }
                else
                {
                    AllNumber1 = 0;
                }
            }
            catch { AllNumber1 = 0; }
            try
            {
                if (Session["AllNumber2"] != null)
                {
                    AllNumber2 = Int64.Parse(Session["AllNumber2"].ToString());
                }
                else
                {
                    AllNumber2 = 0;
                }
            }
            catch { AllNumber2 = 0; }
            int AllCount = 0;
            try
            {
                if (Session["AllCount"] != null)
                {
                    AllCount = int.Parse(Session["AllCount"].ToString());
                }
                else
                {
                    AllCount = 0;
                }
            }
            catch { AllCount = 0; }
            try
            {
                if (model != null)
                {
                    var obj = model.FirstOrDefault(r => r.Id == TempId);
                    var objTemp = db.Product_Table.FirstOrDefault(r => r.ProductId == TempId);
                    if (obj != null)
                    {
                        var ObjFind = obj;
                        foreach (var person in model)
                        {
                            ClientOrder_Manager M = new ClientOrder_Manager();
                            if (person.Id == TempId)
                            {
                                Product_Table Obj = db.Product_Table.Find(person.Id);
                                M.Id = person.Id;
                                M.Name = Obj.Name;
                                M.Image = Obj.Imageurl;
                                M.Price = NumberFormat(Obj.Price.Value.ToString());
                                M.Number = (int.Parse(person.Number) + NumberId).ToString();
                                M.RowTotal = NumberFormat((objTemp.Price.Value * (int.Parse(person.Number) + NumberId)).ToString());
                                M.RowTotal1 = (objTemp.Price.Value * (int.Parse(person.Number) + NumberId));
                                AllNumber1 += (Obj.Price.Value * NumberId);
                                M.AllPrice = NumberFormat(AllNumber1.ToString());
                                BasketProduct.Add(M);
                                modelEdit = (List<ClientOrder_Manager>)BasketProduct;
                            }
                            else
                            {
                                Product_Table Obj = db.Product_Table.Find(person.Id);
                                M.Id = person.Id;
                                M.Name = Obj.Name;
                                M.Image = Obj.Imageurl;
                                M.Price = NumberFormat(Obj.Price.Value.ToString());
                                M.Number = person.Number;
                                M.RowTotal = NumberFormat((Obj.Price.Value * int.Parse(person.Number)).ToString());
                                M.RowTotal1 = (Obj.Price.Value * int.Parse(person.Number));
                                M.AllPrice = NumberFormat(AllNumber1.ToString());

                                BasketProduct.Add(M);
                                AllCount += 1;
                                modelEdit = (List<ClientOrder_Manager>)BasketProduct;
                            }
                        }
                        model = modelEdit;
                        Session.Add("MyClientOrder", modelEdit);
                        Session.Add("AllNumber1", AllNumber1.ToString());

                    }
                    else
                    {
                        Product_Table Obj = db.Product_Table.Find(TempId);
                        ClientOrder_Manager M = new ClientOrder_Manager();
                        M.Id = TempId;
                        M.Name = Obj.Name;
                        M.Image = Obj.Imageurl;
                        M.Price = NumberFormat(Obj.Price.Value.ToString());
                        M.Number = NumberId.ToString();
                        M.RowTotal = NumberFormat((Obj.Price.Value * NumberId).ToString());
                        M.RowTotal1 = (Obj.Price.Value * NumberId);

                        model.Add(M);
                        AllNumber1 += (Obj.Price.Value * NumberId);

                        AllCount += 1;
                        M.AllPrice = NumberFormat(AllNumber1.ToString());

                        BasketProduct.Add(M);
                        Session.Add("AllNumber1", AllNumber1.ToString());

                        Session.Add("MyClientOrder", model);
                    }
                }
                else
                {
                    ClientOrder_Manager M = new ClientOrder_Manager();
                    Product_Table Obj = db.Product_Table.Find(TempId);
                    M.Id = TempId;
                    M.Name = Obj.Name;
                    M.Image = Obj.Imageurl;
                    M.Price = NumberFormat(Obj.Price.Value.ToString());

                    M.Number = NumberId.ToString();
                    M.RowTotal = NumberFormat((Obj.Price.Value * NumberId).ToString());
                    M.RowTotal1 = (Obj.Price.Value * NumberId);

                    BasketProduct.Add(M);
                    Session.Add("MyClientOrder", BasketProduct);
                    AllCount += 1;
                    AllNumber1 += (Obj.Price.Value * NumberId);

                    M.AllPrice = NumberFormat(AllNumber1.ToString());

                    Session.Add("AllNumber1", (NumberId * Obj.Price.Value).ToString());

                    model = (List<ClientOrder_Manager>)Session["MyClientOrder"];
                }
            }
            catch { }
            Session.Add("AllCount", AllCount);
            Main MM = new Main();
            RegisterClient NN = new RegisterClient();
            MM.BasketClass = model;
            MM.ValidationRegister = NN;
            string nn = Session["AllNumber1"].ToString();
            return RedirectToAction("Basket", "Home");
        }
        public ActionResult DeleteRow(int TempId = 0)
        {
            Int64 AllNumber = 0;

            IEnumerable<ClientOrder_Manager> model = (IEnumerable<ClientOrder_Manager>)Session["MyClientOrder"];
            IEnumerable<ClientOrder_Manager> modelEdit = null;

            foreach (var person in model)
            {
                if (person.Id != TempId)
                {
                    ClientOrder_Manager M = new ClientOrder_Manager();
                    Product_Table Obj = db.Product_Table.Find(person.Id);
                    M.Id = person.Id;
                    M.Name = Obj.Name;
                    M.Image = Obj.Imageurl;
                    M.Price = NumberFormat(Obj.Price.Value.ToString());
                    M.Number = person.Number;
                    M.RowTotal = NumberFormat((Obj.Price.Value * int.Parse(person.Number)).ToString());
                    M.RowTotal1 = (Obj.Price.Value * int.Parse(person.Number));


                    AllNumber += (Obj.Price.Value * int.Parse(person.Number));
                    M.AllPrice = NumberFormat(AllNumber.ToString());
                    BasketProduct.Add(M);
                    modelEdit = (List<ClientOrder_Manager>)BasketProduct;

                }

            }
            model = modelEdit;
            Session.Add("AllNumber1", AllNumber.ToString());
            Session["MyClientOrder"] = model;
            return Json(BasketProduct, JsonRequestBehavior.AllowGet);

        }
        public ActionResult CallChangefunc(int TempId = 0, int ProductId = 0)
        {
            Int64 AllNumber = 0;

            IEnumerable<ClientOrder_Manager> model = (IEnumerable<ClientOrder_Manager>)Session["MyClientOrder"];
            IEnumerable<ClientOrder_Manager> modelEdit = null;

            foreach (var person in model)
            {
                ClientOrder_Manager M = new ClientOrder_Manager();
                Product_Table Obj = db.Product_Table.Find(person.Id);
                M.Id = person.Id;
                M.Name = Obj.Name;
                M.Image = Obj.Imageurl;
                M.Price = NumberFormat(Obj.Price.Value.ToString());
                if (person.Id == ProductId)
                {
                    if (TempId == 1)
                    {
                        M.Number = (int.Parse(person.Number) + 1).ToString();
                        M.RowTotal = NumberFormat((Obj.Price.Value * (int.Parse(person.Number) + 1)).ToString());
                        M.RowTotal1 = (Obj.Price.Value * (int.Parse(person.Number) + 1));
                        AllNumber += (Obj.Price.Value * (int.Parse(person.Number) + 1));
                    }
                    else
                    {
                        if (person.Number != "1")
                        {
                            M.Number = (int.Parse(person.Number) - 1).ToString();

                            M.RowTotal = NumberFormat((Obj.Price.Value * (int.Parse(person.Number) - 1)).ToString());
                            M.RowTotal1 = (Obj.Price.Value * (int.Parse(person.Number) - 1));
                            AllNumber += (Obj.Price.Value * (int.Parse(person.Number) - 1));
                        }
                        else
                        {
                            M.Number = "1";
                            M.RowTotal = NumberFormat(Obj.Price.Value.ToString());
                            M.RowTotal1 = Obj.Price.Value;
                            AllNumber += Obj.Price.Value;
                        }
                    }
                }
                else
                {
                    M.Number = person.Number;
                    M.RowTotal = NumberFormat((Obj.Price.Value * int.Parse(person.Number)).ToString());
                    M.RowTotal1 = (Obj.Price.Value * int.Parse(person.Number));
                    AllNumber += (Obj.Price.Value * int.Parse(person.Number));
                }

                M.AllPrice = NumberFormat(AllNumber.ToString());


                BasketProduct.Add(M);
                modelEdit = (List<ClientOrder_Manager>)BasketProduct;
            }
            model = modelEdit;
            Session.Add("AllNumber1", AllNumber.ToString());
            Session["MyClientOrder"] = model;
            return Json(BasketProduct, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Checkout()
        {
            if (Session["UserSite"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Signin", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FrmCHECKOUT(Main mymodel)
        {
            try
            {
                Address_Table Obj = new Address_Table { PersonName = mymodel.ValidationAddress.PersonName, PostalCode = mymodel.ValidationAddress.PostalCode, Title = mymodel.ValidationAddress.Title, Tele = mymodel.ValidationAddress.Tele, Address = mymodel.ValidationAddress.AddressName, UserId = int.Parse(Session["UserSite"].ToString()) };
                db.Address_Table.Add(Obj);
                db.SaveChanges();
                if (Obj != null)
                {
                    TempData["StatusFailed"] = "آدرس با موفقیت ثبت شد";
                    return RedirectToAction("Checkout", "Home");
                }
                else
                {
                    TempData["StatusFailed"] = "عملیات با شکست انجام شد. با مدیر سایت تماس بگیرید";
                    return RedirectToAction("Checkout", "Home");
                }
            }
            catch
            {
                TempData["StatusFailed"] = "عملیات با شکست انجام شد. با مدیر سایت تماس بگیرید";
                return RedirectToAction("Checkout", "Home");
            }
        }
        public ActionResult Verify()
        {
            if (Request.QueryString["Status"] != "" && Request.QueryString["Status"] != null && Request.QueryString["Authority"] != "" && Request.QueryString["Authority"] != null)
            {
                Session["Status"] = -1;
                if (Request.QueryString["Status"].ToString().Equals("OK"))
                {

                    int Amount = int.Parse(Session["AllToman"].ToString());
                    long RefID;
                    com.zarinpal.www.PaymentGatewayImplementationService M = new com.zarinpal.www.PaymentGatewayImplementationService();

                    int Status = M.PaymentVerification("5429942a-7403-11e6-b531-005056a205be", Request.QueryString["Authority"].ToString(), Amount, out RefID);

                    if (Status == 100)
                    {
                        Order_Table Obj = null;
                        int CopenId = 0;
                        try
                        {
                            CopenId = int.Parse(Session["Copen"].ToString());
                            Session["Copen"] = "";
                        }
                        catch { CopenId = 0; Session["Copen"] = ""; }
                        if (CopenId != 0)
                        {
                            Obj = new Order_Table { RegisterId = int.Parse(Session["UserSite"].ToString()), DateSales = DateTime.Now, FactorCode = RefID.ToString(), CopenId = CopenId, Status = 2 };
                            db.Order_Table.Add(Obj);
                            db.SaveChanges();
                        }
                        else
                        {
                            Obj = new Order_Table { RegisterId = int.Parse(Session["UserSite"].ToString()), DateSales = DateTime.Now, FactorCode = RefID.ToString(), Status = 2 };
                            db.Order_Table.Add(Obj);
                            db.SaveChanges();
                        }

                        ///////////////////////////////////////////////////////////
                        var model = Session["MyClientOrder"] as List<ClientOrder_Manager>;
                        if (model != null)
                        {
                            if (model.Any())
                            {
                                foreach (var item in model)
                                {
                                    try
                                    {
                                        OrderDetail_Table ObjDetail = null;
                                        Product_Table ObjPro = null;

                                        ObjPro = db.Product_Table.FirstOrDefault(r => r.ProductId == item.Id);
                                        ObjDetail = new OrderDetail_Table { OrderId = Obj.OrderId, ProductId = item.Id, Number = int.Parse(item.Number.ToString()), Price = ObjPro.Price.Value };
                                        db.OrderDetail_Table.Add(ObjDetail);
                                        db.SaveChanges();

                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                Session["MyClientOrder"] = "";

                                Session["Status"] = "2";


                            }

                        }
                        return RedirectToAction("Successed", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Failed", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Failed", "Home");
                }
            }
            else
            {
                return RedirectToAction("Failed", "Home");
            }

        }
        public ActionResult Successed()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Failed()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Payment()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FrmPeymant(int MyPrice = 0)
        {
            try
            {
                int UserId = int.Parse(Session["UserSite"].ToString());
                com.zarinpal.www.PaymentGatewayImplementationService M = new com.zarinpal.www.PaymentGatewayImplementationService();
                string aaa;

                var ObjUser = db.User_Table.FirstOrDefault(r => r.UserId == UserId);
                string Description = "Factor" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                string Email = ObjUser.Email;
                string Mobile = "";




                int Status = M.PaymentRequest("5429942a-7403-11e6-b531-005056a205be", MyPrice, Description, Email, Mobile, "http://ironika.ir/Verify", out aaa);
                if (Status == 100)
                {
                    Response.Redirect("https://www.zarinpal.com/pg/StartPay/" + aaa);
                }
                return View();
            }
            catch
            {
                TempData["StatusFailed"] = "Operation Failed . Please Contact Admin!";
                return RedirectToAction("CHECKOUT", "Home");
            }
        }
        public ActionResult ShopPage(string Id)
        {
            lstBig_Menu = new List<GroupShop>();
            lstParent_Menu = new List<GroupShop>();
            lstChild_Menu = new List<GroupShop>();
            if (Id != null)
            {
                string Name = Id.Trim().Replace("-", " ");
                ViewBag.Name = Name;
                ViewBag.MenuName = Name;
                ViewBag.BigMenu = lstBig_Menu;
                ViewBag.ParentMenu = lstParent_Menu;
                ViewBag.ChildMenu = lstChild_Menu;

                int SupperId = 0; int GroupId = 0; string GroupName = "";

                List<OwnerProduct_Table> lst_Product = new List<OwnerProduct_Table>();

                var ObjsSupper = db.Supper_Table.FirstOrDefault(r => r.ShopName == Name);
                if (ObjsSupper != null)
                {
                    SupperId = ObjsSupper.SupperId;
                    lst_Product = db.OwnerProduct_Table.Where(r => r.SupperId == SupperId && r.State == true).OrderByDescending(r => r.OwnerProductId).ToList();
                    if (lst_Product.Count() > 0)
                    {
                        int KindId = lst_Product[0].Product_Table.Kind.Value;
                        var ObjMenu = db.Menu_Table.FirstOrDefault(r => r.Kind == KindId);
                        if (ObjMenu != null)
                        {
                            ViewBag.MenuName = ObjMenu.Title;
                        }
                        else
                        {
                            ViewBag.MenuName = "";
                        }
                        foreach (var item in lst_Product)
                        {
                            GroupId = item.Product_Table.GroupId.Value;
                            var ObjsGroup = db.Group_Table.FirstOrDefault(r => r.GroupId == GroupId);
                            if (ObjsGroup != null)
                            {
                                GroupName = ObjsGroup.Name;
                                if (lstChild_Menu.Where(r => r.Name == GroupName).Count() == 0)
                                {
                                    GroupShop m = new GroupShop();
                                    m.Name = ObjsGroup.Name;
                                    m.Parent = ObjsGroup.Parent.Value;
                                    m.GroupId = ObjsGroup.GroupId;
                                    FunParent(ObjsGroup.Parent.Value);
                                    lstChild_Menu.Add(m);
                                }
                            }
                        }
                    }
                }                
            }            
            return View();
        }
        public void FunParent(int ?parent)
        {
            string GroupName = "";
            if (parent!=null)
            {
                var Objs = db.Group_Table.FirstOrDefault(r => r.GroupId == parent);
                if(Objs!=null)
                {
                    GroupName = Objs.Name;
                    if (lstParent_Menu.Where(r => r.Name == GroupName).Count() == 0)
                    {
                        GroupShop m = new GroupShop();
                        m.Name = Objs.Name;
                        m.Parent = Objs.Parent;
                        m.GroupId = Objs.GroupId;
                        FunBig(Objs.Parent);
                        lstParent_Menu.Add(m);
                    }
                }
            }
        }
        public void FunBig(int? parent)
        {
            string GroupName = "";
            if (parent != null)
            {
                var Objs = db.Group_Table.FirstOrDefault(r => r.GroupId == parent);
                if (Objs != null)
                {
                    GroupName = Objs.Name;
                    if (lstBig_Menu.Where(r => r.Name == GroupName).Count() == 0)
                    {
                        GroupShop m = new GroupShop();
                        m.Name = Objs.Name;
                        m.Parent = Objs.Parent;
                        m.GroupId = Objs.GroupId;                        
                        lstBig_Menu.Add(m);
                    }
                }
            }
        }
    }
}