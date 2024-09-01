using Ironika_Theme1.Panel.SupperMarket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ironika_Theme1.Models
{
    public class Order_Manager
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        public List<Order_Table> GetProvider(string Text, int startRowIndex, int maximumRows)
        {

            return (from list in db.Order_Table select list)
               .Where(r => r.Status == 1)
                   .OrderByDescending(customer => customer.OrderId)
                   .Skip(startRowIndex)
                   .Take(maximumRows).ToList();

        }

        public int GetProvider_Count(string Text, int startRowIndex, int maximumRows)
        {

            return (from list in db.Order_Table select list)
                .Where(r => r.Status == 1)
                  .Count();

        }
        public int delete(int OrderId)
        {
            int _ret = 0;
            using (Tezol_DBEntities db = new Tezol_DBEntities())
            {
                var itemToRemove = db.Order_Table.SingleOrDefault(x => x.OrderId == OrderId);

                if (itemToRemove != null)
                {
                    db.Order_Table.Remove(itemToRemove);
                    db.SaveChanges();
                }
            }
            db.Dispose();
            return _ret;
        }
        public List<Order_Table> GetProvider_Supper(int SupperId,string Text, int startRowIndex, int maximumRows)
        {

            return (from list in db.Order_Table select list)
               .Where(r => r.SupperId== SupperId)
                   .OrderByDescending(customer => customer.OrderId)
                   .Skip(startRowIndex)
                   .Take(maximumRows).ToList();

        }
        public int GetProvider_Count_Supper(int SupperId, string Text, int startRowIndex, int maximumRows)
        {
            return (from list in db.Order_Table select list)
                .Where(r => r.SupperId == SupperId)
                  .Count();
        }
        public List<Order_Table> GetProvider_SupperDate(int SupperId,DateTime StartDate,DateTime EndDate, string Text, int startRowIndex, int maximumRows)
        {
           
            return (from list in db.Order_Table select list)
               .Where(r => r.SupperId == SupperId && r.DateSales.Value>= StartDate && r.DateSales.Value<=EndDate)
                   .OrderByDescending(customer => customer.OrderId)
                   .Skip(startRowIndex)
                   .Take(maximumRows).ToList();

        }
        public int GetProvider_Count_SupperDate(int SupperId, DateTime StartDate, DateTime EndDate, string Text, int startRowIndex, int maximumRows)
        {
            return (from list in db.Order_Table select list)
                .Where(r => r.SupperId == SupperId && r.DateSales.Value >= StartDate && r.DateSales.Value <= EndDate)
                  .Count();
        }
    }
}