using Ebooks.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ebooks.Models
{
    public class Cart
    {
        MyDataDataContext data = new MyDataDataContext();
        public int book_id { get; set; }

        public string category_name { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string image { get; set; }

        public double price { get; set; }

        public int qty { get; set; }

        public double total
        {
            get { return qty * price; }
        }

        public Cart(int id)
        {
            book_id = id;
            Book book = data.Books.Single(n => n.id == id);
            category_name = book.category.name;
            name = book.title;
            author = book.author;
            image = book.image_path;
            price = double.Parse(book.price.ToString());
            qty = 1;
        }
    }
}