using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebooks.Models
{
    public class CustomerOrder
    {
        public string BookImage { get; set; }
        public string BookName { get; set; }
        public int BookAmount { get; set; }
        public string BookCate { get; set; }
        public double BookUnitPrice { get; set; }
        public double TotalPriceBook { get; set; }
    }
}