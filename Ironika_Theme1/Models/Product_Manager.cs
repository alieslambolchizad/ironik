using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ironika_Theme1.Models
{
    public class Product_Manager
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        public List<OwnerProduct_Table> GetProvider(int SupperId, string Text, int startRowIndex, int maximumRows)
        {
            return (from list in db.OwnerProduct_Table select list)
               .Where(r =>r.SupperId== SupperId )
                   .OrderByDescending(customer => customer.OwnerProductId)
                   .Skip(startRowIndex)
                   .Take(maximumRows).ToList();

        }

        public int GetProvider_Count(int SupperId, string Text, int startRowIndex, int maximumRows)
        {

            return (from list in db.OwnerProduct_Table select list)
               .Where(r => r.SupperId == SupperId)
                  .Count();

        }
        public int delete(int OwnerProductId)
        {
            int _ret = 0;
            using (Tezol_DBEntities db = new Tezol_DBEntities())
            {
                var itemToRemove = db.OwnerProduct_Table.SingleOrDefault(x => x.OwnerProductId == OwnerProductId);

                if (itemToRemove != null)
                {
                    db.OwnerProduct_Table.Remove(itemToRemove);
                    db.SaveChanges();
                }
            }
            db.Dispose();
            return _ret;
        }
        public List<Product_Table> GetProvider_ProductGroup(int GroupId)
        {
            return (from list in db.Product_Table select list)
               .Where(r => r.GroupId == GroupId)
                   .OrderBy(customer => customer.ProductId)
                   .ToList();

        }
    }
}