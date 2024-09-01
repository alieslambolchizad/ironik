using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Ironika_Theme1.Models
{
    public class Date_Manager
    {
        public static string ConvertDate(DateTime LatinTime)
        {
            try
            {
                PersianCalendar jc = new PersianCalendar();
                DateTime thisDate = LatinTime;

                string day;
                string month;
                string year;
                string newdate = "";
                day = jc.GetDayOfMonth(thisDate).ToString();
                month = jc.GetMonth(thisDate).ToString();
                year = jc.GetYear(thisDate).ToString();
                if (int.Parse(day) < 10)
                    day = "0" + day;
                if (int.Parse(month) < 10)
                    month = "0" + month;
                newdate = year + "/" + month + "/" + day;
                return newdate;
            }
            catch { return ""; }
        }
        public static string FarsiDate(string FarsiTime)
        {
            try
            {
                PersianCalendar jc = new PersianCalendar();
                string[] thisDate = FarsiTime.Split('/');

                string day;
                string month;
                string year;
                string newdate = "";
                day = thisDate[2];
                month = thisDate[1];
                year = thisDate[0];
                if (int.Parse(day) < 10)
                    day = "0" + day;
                if (int.Parse(month) < 10)
                    month = "0" + month;
                newdate = year + "/" + month + "/" + day;
                return newdate;
            }
            catch { return ""; }
        }
        public static DateTime Latin(string FarsiTime)
        {
            try
            {
                PersianCalendar jc = new PersianCalendar();
                string[] thisDate = FarsiTime.Split('/');

                string day;
                string month;
                string year;

                day = thisDate[2];
                month = thisDate[1];
                year = thisDate[0];

                if (int.Parse(day) < 10)
                    day = "0" + day;
                if (int.Parse(month) < 10)
                    month = "0" + month;
                DateTime Date = jc.ToDateTime(int.Parse(year), int.Parse(month), int.Parse(day), 0, 0, 0, 0);
                return Date;
            }
            catch { return Convert.ToDateTime(null); }
        }
    }
}
