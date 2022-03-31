using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebooks.Areas.Admin.Models
{
    public class BookOrder
    {
        public string Book_image { get; set; }
        public string Book_name { get; set; }
        public string Book_author { get; set; }
        public double Book_price { get; set; }
        public int Book_qty { get; set; }

        public double Book_total { get; set; }
    }
}