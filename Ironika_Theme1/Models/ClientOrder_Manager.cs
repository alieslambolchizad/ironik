using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ironika_Theme1.Models
{
    public class ClientOrder_Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }

        public string Number { get; set; }
        public string RowTotal { get; set; }
        public int RowTotal1 { get; set; }
        public string DateReserve { get; set; }
        public string AllPrice { get; set; }
    }
}