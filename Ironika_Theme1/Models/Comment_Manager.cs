using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ironika_Theme1.Models
{
    public class Comment_Manager
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        public List<Review_Table> GetProvider(int SupperId, string Text, int startRowIndex, int maximumRows)
        {
            return (from list in db.Review_Table select list)
                .Where(r=>r.SupperId== SupperId && r.State==false)
                   .OrderByDescending(customer => customer.ReviewId)
                   .Skip(startRowIndex)
                   .Take(maximumRows).ToList();

        }

        public int GetProvider_Count(int SupperId, string Text, int startRowIndex, int maximumRows)
        {

            return (from list in db.Review_Table select list)
                .Where(r => r.SupperId == SupperId && r.State == false)
                  .Count();

        }
        public int delete(int ReviewId)
        {
            int _ret = 0;
            using (Tezol_DBEntities db = new Tezol_DBEntities())
            {
                var itemToRemove = db.Review_Table.SingleOrDefault(x => x.ReviewId == ReviewId);

                if (itemToRemove != null)
                {
                    db.Review_Table.Remove(itemToRemove);
                    db.SaveChanges();
                }
            }
            db.Dispose();
            return _ret;
        }
    }
}