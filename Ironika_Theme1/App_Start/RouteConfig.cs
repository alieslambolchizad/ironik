using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ironika_Theme1
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                    name: "DefaultAspx",
                    url: "WebForm1.aspx",
                    defaults: new { controller = "MyAspxPage", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapPageRoute("CancelOrder", "Admin/CancelOrder", "~/Admin/CancelOrder.aspx", true, null, new RouteValueDictionary { { "outgoing", new MyCustomConstaint() } });
            routes.MapPageRoute("Ticket", "Admin/Ticket", "~/Admin/Ticket.aspx", true, null, new RouteValueDictionary { { "outgoing", new MyCustomConstaint() } });
            routes.MapPageRoute("TicketList", "Admin/TicketList", "~/Admin/TicketList.aspx", true, null, new RouteValueDictionary { { "outgoing", new MyCustomConstaint() } });
            routes.MapPageRoute("ChangePass", "Admin/ChangePass", "~/Admin/ChangePass.aspx", true, null, new RouteValueDictionary { { "outgoing", new MyCustomConstaint() } });
            routes.MapPageRoute("Dashboard", "Admin/Dashboard", "~/Admin/Dashboard.aspx", true, null, new RouteValueDictionary { { "outgoing", new MyCustomConstaint() } });
            routes.MapPageRoute("DeliveryOrder", "Admin/DeliveryOrder", "~/Admin/DeliveryOrder.aspx", true, null, new RouteValueDictionary { { "outgoing", new MyCustomConstaint() } });
            routes.MapPageRoute("LikeList", "Admin/LikeList", "~/Admin/LikeList.aspx", true, null, new RouteValueDictionary { { "outgoing", new MyCustomConstaint() } });
            routes.MapPageRoute("Logout", "Admin/Logout", "~/Admin/Logout.aspx", true, null, new RouteValueDictionary { { "outgoing", new MyCustomConstaint() } });
            routes.MapPageRoute("ProcessOrder", "Admin/ProcessOrder", "~/Admin/ProcessOrder.aspx", true, null, new RouteValueDictionary { { "outgoing", new MyCustomConstaint() } });
            routes.MapPageRoute("UserProfile", "Admin/UserProfile", "~/Admin/UserProfile.aspx", true, null, new RouteValueDictionary { { "outgoing", new MyCustomConstaint() } });
            routes.MapPageRoute("WaitingOrder", "Admin/WaitingOrder", "~/Admin/WaitingOrder.aspx", true, null, new RouteValueDictionary { { "outgoing", new MyCustomConstaint() } });

            routes.MapRoute(name: "About", url: "About", defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional });
            routes.MapRoute(name: "Contact", url: "Contact", defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional });
            routes.MapRoute(name: "Privacy", url: "Privacy", defaults: new { controller = "Home", action = "Privacy", id = UrlParameter.Optional });
            routes.MapRoute(name: "Terms", url: "Terms", defaults: new { controller = "Home", action = "Terms", id = UrlParameter.Optional });
            routes.MapRoute(name: "Faq", url: "Faq", defaults: new { controller = "Home", action = "Faq", id = UrlParameter.Optional });

            
            routes.MapRoute(name: "Signup", url: "Signup", defaults: new { controller = "Home", action = "Signup", id = UrlParameter.Optional });
            routes.MapRoute(name: "Signin", url: "Signin", defaults: new { controller = "Home", action = "Signin", id = UrlParameter.Optional });
            routes.MapRoute(name: "Exit", url: "Exit", defaults: new { controller = "Home", action = "Exit", id = UrlParameter.Optional });
            routes.MapRoute(name: "Forget", url: "Forget", defaults: new { controller = "Home", action = "Forget", id = UrlParameter.Optional });
            routes.MapRoute(name: "LikeShopList", url: "LikeShopList", defaults: new { controller = "Home", action = "LikeShopList", id = UrlParameter.Optional });
            routes.MapRoute(name: "LikeProductList", url: "LikeProductList", defaults: new { controller = "Home", action = "LikeProductList", id = UrlParameter.Optional });
            routes.MapRoute(name: "SigninFa", url: "SigninFa", defaults: new { controller = "HomeFa", action = "Signin", id = UrlParameter.Optional });
            routes.MapRoute(name: "ExitFa", url: "ExitFa", defaults: new { controller = "HomeFa", action = "Exit", id = UrlParameter.Optional });
            routes.MapRoute(name: "ForgetFa", url: "ForgetFa", defaults: new { controller = "HomeFa", action = "Forget", id = UrlParameter.Optional });
            
            routes.MapRoute(name: "Basket", url: "Basket", defaults: new { controller = "Home", action = "Basket", id = UrlParameter.Optional });
            //routes.MapRoute(name: "Likelist", url: "Likelist", defaults: new { controller = "Home", action = "Likelist", id = UrlParameter.Optional });
            routes.MapRoute(name: "BasketFa", url: "BasketFa", defaults: new { controller = "HomeFa", action = "Basket", id = UrlParameter.Optional });
            routes.MapRoute(name: "LikelistFa", url: "LikelistFa", defaults: new { controller = "HomeFa", action = "Likelist", id = UrlParameter.Optional });
            routes.MapRoute(name: "Payment", url: "Payment", defaults: new { controller = "Home", action = "Payment", id = UrlParameter.Optional });
            routes.MapRoute(name: "Verify", url: "Verify", defaults: new { controller = "Home", action = "Verify", id = UrlParameter.Optional });
            routes.MapRoute(name: "PaymentFa", url: "PaymentFa", defaults: new { controller = "HomeFa", action = "Payment", id = UrlParameter.Optional });
            routes.MapRoute(name: "Successed", url: "Successed", defaults: new { controller = "Home", action = "Successed", id = UrlParameter.Optional });
            routes.MapRoute(name: "Failed", url: "Failed", defaults: new { controller = "Home", action = "Failed", id = UrlParameter.Optional });
            routes.MapRoute(name: "SuccessedFa", url: "SuccessedFa", defaults: new { controller = "HomeFa", action = "Successed", id = UrlParameter.Optional });
            routes.MapRoute(name: "FailedFa", url: "FailedFa", defaults: new { controller = "HomeFa", action = "Failed", id = UrlParameter.Optional });
            routes.MapRoute(name: "PurchaseArchive", url: "PurchaseArchive", defaults: new { controller = "Home", action = "PurchaseArchive", id = UrlParameter.Optional });
            routes.MapRoute(name: "CHECKOUT", url: "CHECKOUT", defaults: new { controller = "Home", action = "CHECKOUT", id = UrlParameter.Optional });
            routes.MapRoute(name: "ChangePAssword", url: "ChangePAssword", defaults: new { controller = "Home", action = "ChangePAssword", id = UrlParameter.Optional });


            routes.MapRoute(name: "Listing", url: "Listing/{id}/{action}", defaults: new { controller = "Home", action = "Listing", id = UrlParameter.Optional });
            routes.MapRoute(name: "ShopList", url: "ShopList/{id}/{action}", defaults: new { controller = "Home", action = "ShopList", id = UrlParameter.Optional });
            routes.MapRoute(name: "Comment", url: "Comment/{id}/{action}", defaults: new { controller = "Home", action = "Comment", id = UrlParameter.Optional });
            routes.MapRoute(name: "AllGroups", url: "AllGroups/{id}/{action}", defaults: new { controller = "Home", action = "AllGroups", id = UrlParameter.Optional });
            routes.MapRoute(name: "ShopPage", url: "ShopPage/{id}/{action}", defaults: new { controller = "Home", action = "ShopPage", id = UrlParameter.Optional });
            routes.MapRoute(name: "Products", url: "Products/{id}/{action}", defaults: new { controller = "Home", action = "Products", id = UrlParameter.Optional });
            routes.MapRoute(name: "Pages", url: "Pages/{id}/{action}", defaults: new { controller = "Home", action = "Pages", id = UrlParameter.Optional });
            routes.MapRoute(name: "ProductGroupsFa", url: "ProductGroupsFa/{id}/{action}", defaults: new { controller = "HomeFa", action = "ProductGroups", id = UrlParameter.Optional });
            routes.MapRoute(name: "Details", url: "Details/{id}/{action}", defaults: new { controller = "Home", action = "Details", id = UrlParameter.Optional });
            routes.MapRoute(name: "Brands", url: "Brands/{id}/{action}", defaults: new { controller = "Home", action = "Brands", id = UrlParameter.Optional });
            routes.MapRoute(name: "BrandsFa", url: "BrandsFa/{id}/{action}", defaults: new { controller = "HomeFa", action = "Brands", id = UrlParameter.Optional });
            routes.MapRoute(name: "Admin4", url: "Newset/{id}/{action}", defaults: new { controller = "Home", action = "Newset", id = UrlParameter.Optional });
            routes.MapRoute(name: "Admin5", url: "Artister/{id}/{action}", defaults: new { controller = "Home", action = "Artister", id = UrlParameter.Optional });
            routes.MapRoute(name: "Admin6", url: "AllArtisters/{id}/{action}", defaults: new { controller = "Home", action = "AllArtisters", id = UrlParameter.Optional });
            routes.MapRoute(name: "Admin7", url: "AllNewset/{id}/{action}", defaults: new { controller = "Home", action = "AllNewset", id = UrlParameter.Optional });
            routes.MapRoute(name: "Admin8", url: "ProductPriceing/{id}/{action}", defaults: new { controller = "Home", action = "ProductPriceing", id = UrlParameter.Optional });
            routes.MapRoute(name: "Admin3", url: "Groups/{id}/{action}", defaults: new { controller = "Home", action = "Groups", id = UrlParameter.Optional });
            routes.MapRoute(name: "DetailsNews", url: "DetailsNews/{id}/{action}", defaults: new { controller = "Home", action = "DetailsNews", id = UrlParameter.Optional });
            routes.MapRoute(name: "DetailsFa", url: "DetailsFa/{id}/{action}", defaults: new { controller = "HomeFa", action = "Details", id = UrlParameter.Optional });
            routes.MapRoute(name: "SearchList", url: "SearchList/{id}/{action}", defaults: new { controller = "Home", action = "SearchList", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
       
        protected void Application_Start()
        {
            
            RegisterRoutes(RouteTable.Routes);
        }
    }
}