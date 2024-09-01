using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ironika_Theme1.Models
{
    public class GroupingShop_Manager
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        public List<GroupShop_Table> GetProvider(int SupperId, string Text, int startRowIndex, int maximumRows)
        {
            return (from list in db.GroupShop_Table select list)
                .Where(r=>r.SupperId== SupperId )
                   .OrderByDescending(customer => customer.GroupId)
                   .Skip(startRowIndex)
                   .Take(maximumRows).ToList();

        }

        public int GetProvider_Count(int SupperId, string Text, int startRowIndex, int maximumRows)
        {

            return (from list in db.GroupShop_Table select list)
                .Where(r => r.SupperId == SupperId )
                  .Count();

        }
        public int delete(int GroupId)
        {
            int _ret = 0;
            using (Tezol_DBEntities db = new Tezol_DBEntities())
            {
                var itemToRemove = db.GroupShop_Table.SingleOrDefault(x => x.GroupId == GroupId);

                if (itemToRemove != null)
                {
                    db.GroupShop_Table.Remove(itemToRemove);
                    db.SaveChanges();
                }
            }
            db.Dispose();
            return _ret;
        }
        public List<GroupShop_Table> GetProvider_NoPageing(int SupperId)
        {
            return (from list in db.GroupShop_Table select list)
                .Where(r => r.SupperId == SupperId)
                   .OrderBy(customer => customer.Name)
                   .ToList();

        }
        
    }
}