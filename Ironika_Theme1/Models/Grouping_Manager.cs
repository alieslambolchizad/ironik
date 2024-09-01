using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ironika_Theme1.Models
{
    public class Grouping_Manager
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        public List<OwenerGroup_Table> GetProvider(int SupperId, string Text, int startRowIndex, int maximumRows)
        {
            return (from list in db.OwenerGroup_Table select list)
                .Where(r=>r.SupperId== SupperId )
                   .OrderByDescending(customer => customer.OwnerGroupId)
                   .Skip(startRowIndex)
                   .Take(maximumRows).ToList();

        }

        public int GetProvider_Count(int SupperId, string Text, int startRowIndex, int maximumRows)
        {

            return (from list in db.OwenerGroup_Table select list)
                .Where(r => r.SupperId == SupperId )
                  .Count();

        }
        public int delete(int OwnerGroupId)
        {
            int _ret = 0;
            using (Tezol_DBEntities db = new Tezol_DBEntities())
            {
                var itemToRemove = db.OwenerGroup_Table.SingleOrDefault(x => x.OwnerGroupId == OwnerGroupId);

                if (itemToRemove != null)
                {
                    db.OwenerGroup_Table.Remove(itemToRemove);
                    db.SaveChanges();
                }
            }
            db.Dispose();
            return _ret;
        }
        public List<Group_Table> GetProvider_Big()
        {
            return (from list in db.Group_Table select list)
                .Where(r => r.Parent == null)
                   .OrderBy(customer => customer.Name)
                   .ToList();

        }
        public List<Group_Table> GetProvider_Node(int Parent)
        {
            return (from list in db.Group_Table select list)
                .Where(r => r.Parent == Parent)
                   .OrderBy(customer => customer.Name)
                   .ToList();

        }
        public List<View_Group> GetProvider_MyGroup(int SupperId)
        {
            return (from list in db.View_Group select list)
                .Where(r => r.SupperId == SupperId)
                   .OrderBy(customer => customer.Name)
                   .ToList();

        }
    }
}