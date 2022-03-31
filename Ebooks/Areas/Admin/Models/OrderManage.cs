using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebooks.Areas.Admin.Models
{
    public class OrderManage
    {
        public int Id_Orders { get; set; }
        public DateTime Date_create { get; set; }
        public string Customer_name { get; set; }
        public int Amount_book { get; set; }
        public double Total { get; set; }
        public byte Status_order { get; set; }

      
    }
}