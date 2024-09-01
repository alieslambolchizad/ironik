using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ironika_Theme1.Models
{
    public class Content_Manager
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        public List<Content_Table> GetProvider(int SupperId, int Kind, string Text, int startRowIndex, int maximumRows)
        {
            return (from list in db.Content_Table select list)
               .Where(r =>r.SupperId== SupperId && r.Kind == Kind)
                   .OrderByDescending(customer => customer.ContentId)
                   .Skip(startRowIndex)
                   .Take(maximumRows).ToList();

        }

        public int GetProvider_Count(int SupperId, int Kind, string Text, int startRowIndex, int maximumRows)
        {

            return (from list in db.Content_Table select list)
               .Where(r => r.SupperId == SupperId && r.Kind == Kind)
                  .Count();

        }
        public int delete(int ContentId)
        {
            int _ret = 0;
            using (Tezol_DBEntities db = new Tezol_DBEntities())
            {
                var itemToRemove = db.Content_Table.SingleOrDefault(x => x.ContentId == ContentId);

                if (itemToRemove != null)
                {
                    db.Content_Table.Remove(itemToRemove);
                    db.SaveChanges();
                }
            }
            db.Dispose();
            return _ret;
        }
    }
}