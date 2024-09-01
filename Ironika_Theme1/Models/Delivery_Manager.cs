using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ironika_Theme1.Models
{
    public class Delivery_Manager
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        public List<Delivery_Table> GetProvider(int SupperId, string Text, int startRowIndex, int maximumRows)
        {
            return (from list in db.Delivery_Table select list)
               .Where(r =>r.SupperId== SupperId )
                   .OrderByDescending(customer => customer.DeliveryId)
                   .Skip(startRowIndex)
                   .Take(maximumRows).ToList();

        }

        public int GetProvider_Count(int SupperId, string Text, int startRowIndex, int maximumRows)
        {

            return (from list in db.Delivery_Table select list)
               .Where(r => r.SupperId == SupperId)
                  .Count();

        }
        public int delete(int DeliveryId)
        {
            int _ret = 0;
            using (Tezol_DBEntities db = new Tezol_DBEntities())
            {
                var itemToRemove = db.Delivery_Table.SingleOrDefault(x => x.DeliveryId == DeliveryId);

                if (itemToRemove != null)
                {
                    db.Delivery_Table.Remove(itemToRemove);
                    db.SaveChanges();
                }
            }
            db.Dispose();
            return _ret;
        }
    }
}