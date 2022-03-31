using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebooks.Areas.Admin.Models
{
    public class CustomerOrders
    {
        public int Customer_orderID { get; set; }
        public string Customer_name { get; set; }
        public string Customer_addr { get; set; }
        public double Customer_total { get; set; }

        public byte Customer_status { get; set; }

        public string Customer_phone { get; set; }
    }
}