using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ironika_Theme1.Models
{
    public class EmailModel
    {
        public string Text { get; set; }
        public string RecieverEmail { get; set; }
        public string Email { get; set; }
        public string EmailUser { get; set; }
        public string Subject { get; set; }
        public string FullName { get; set; }
        public string Logo { get; set; }
        public string Facebook { get; set; }
        public string Banner { get; set; }
        public string gPlus { get; set; }
        public string Twitter { get; set; }
        public string Date { get { return DateTime.Now.ToShortDateString(); } set { } }
        public string WebsiteName { get; set; }
        public string WebsiteURL { get; set; }
        public string Tell { get; set; }
        public string CopyRight { get; set; }
        public string Password { get; set; }
    }
}