using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ironika_Theme1.Models
{
    public class ProductShop_Manager
    {
        Tezol_DBEntities db = new Tezol_DBEntities();
        public List<ProductShop_Table> GetProvider(int SupperId, string Text, int startRowIndex, int maximumRows)
        {
            return (from list in db.ProductShop_Table select list)
               .Where(r =>r.GroupShop_Table.SupperId== SupperId )
                   .OrderByDescending(customer => customer.ProductId)
                   .Skip(startRowIndex)
                   .Take(maximumRows).ToList();

        }

        public int GetProvider_Count(int SupperId, string Text, int startRowIndex, int maximumRows)
        {

            return (from list in db.ProductShop_Table select list)
               .Where(r => r.GroupShop_Table.SupperId == SupperId)
                  .Count();

        }
        public int delete(int ProductId)
        {
            int _ret = 0;
            using (Tezol_DBEntities db = new Tezol_DBEntities())
            {
                var itemToRemove = db.ProductShop_Table.SingleOrDefault(x => x.ProductId == ProductId);

                if (itemToRemove != null)
                {
                    db.ProductShop_Table.Remove(itemToRemove);
                    db.SaveChanges();
                }
            }
            db.Dispose();
            return _ret;
        }
      
    }
}