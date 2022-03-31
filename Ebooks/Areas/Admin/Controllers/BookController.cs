using Ebooks.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebooks.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        MyAdminDataDataContext data = new MyAdminDataDataContext();
        // GET: Admin/Book
        public ActionResult ListBook()
        {
            var all_sach = from s in data.Books select s;
            return View(all_sach);
        }
        
        public ActionResult Detail(int id)
        {
            var D_sach = data.Books.Where(m => m.id == id).First();
            return View(D_sach);
        }
        public ActionResult Create()
        {
            // Lấy toàn bộ thể loại:
            List<category> cate = data.categories.ToList();
            // Tạo SelectList
            SelectList cateList = new SelectList(cate, "id", "name");
            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, Book s)
        {
            var E_tenloai = Convert.ToInt32(collection["category_id"]);
            var E_tensach = collection["title"];
            var E_giaban = Convert.ToDouble(collection["price"]);
            var E_soluongton = Convert.ToInt32(collection["qty"]);
            var E_hinh = collection["image_path"];
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.category_id = E_tenloai;
                s.title = E_tensach.ToString();
                s.price = E_giaban;
                s.qty = E_soluongton;
                s.image_path = E_hinh.ToString();
                data.Books.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListBook");
            }
            return this.Create();
        }
        public ActionResult Edit(int id)
        {
            var Category = from ca in data.categories
                           select new { ca.id, ca.name };
            ViewBag.Categories = new SelectList(Category, "id", "name", id);
            var E_sach = data.Books.First(m => m.id == id);
            return View(E_sach);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sach = data.Books.First(m => m.id == id);
            var E_tensach = collection["title"];
            var E_hinh = collection["image_path"];
            var E_giaban = Convert.ToDouble(collection["price"]);
            var E_soluongton = Convert.ToInt32(collection["qty"]);
            E_sach.id = id;
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sach.title = E_tensach;
                E_sach.image_path = E_hinh;
                E_sach.price = E_giaban;
                E_sach.qty = E_soluongton;
                UpdateModel(E_sach);
                data.SubmitChanges();
                return RedirectToAction("ListBook");
            }
            return this.Edit(id);
        }
        //-----------------------------------------
        public ActionResult Delete(int id)
        {
            var D_sach = data.Books.Where(m => m.id == id).First();
            data.Books.DeleteOnSubmit(D_sach);
            data.SubmitChanges();
            return RedirectToAction("ListBook");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Asset/admin/img/" + file.FileName));
            return "/Asset/admin/img/" + file.FileName;
        }

    }
}