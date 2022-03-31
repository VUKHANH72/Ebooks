using Ebooks.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebooks.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        MyAdminDataDataContext data = new MyAdminDataDataContext();
        public ActionResult Index()
        {
            var all_theloai = from tt in data.categories select tt;
            return View(all_theloai);
        }
        public ActionResult Detail(int id)
        {
            var D_theloai = data.categories.Where(m => m.id == id).First();
            return View(D_theloai);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, category tl)
        {
            var ten = collection["name"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.name = ten;
                data.categories.InsertOnSubmit(tl);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(int id)
        {
            var E_category = data.categories.First(m => m.id == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var theloai = data.categories.First(m => m.id == id);
            var E_tenloai = collection["name"];
            theloai.id = id;
            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                theloai.name = E_tenloai;
                UpdateModel(theloai);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(int id)
        {
            var D_theloai = data.categories.Where(m => m.id == id).First();
            data.categories.DeleteOnSubmit(D_theloai);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}