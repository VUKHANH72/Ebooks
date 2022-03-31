using Ebooks.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebooks.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        MyAdminDataDataContext data = new MyAdminDataDataContext();
        // GET: Admin/User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            //Gan cac gia tri nguoi dung nhap lieu cac bien
            var user = collection["User"];
            var password = collection["Password"];
            if (String.IsNullOrEmpty(user))
            {
                ViewData["err1"] = "Bạn cần nhập username";
            }
            else if (String.IsNullOrEmpty(password))
            {
                ViewData["err2"] = "Bạn cần nhập mật khẩu";
            }
            else
            {
                //Gan gia tri cho doi tuong duoc tao moi (customer)
                user ct = data.users.SingleOrDefault(n => n.username == user && n.password == password);
                if (ct != null)
                {
                    ViewBag.Notification = "Chúc mừng bạn đăng nhập thành công";
                    Session["username"] = ct;
                    return RedirectToAction("ListBook", "Book");
                }
                else
                {
                    ViewBag.Notification = "Tên đăng nhập hoặc mật khẩu không đúng";
                }

            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "User");
        }

        public ActionResult MangeUser()
        {
            var all_user = from u in data.users select u;
            return View(all_user);
        }

        public ActionResult Create()
        {
            var type = new List<string> { "Admin", "Staff" };
            SelectList typeList = new SelectList(type);
            ViewBag.TypeUser = typeList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, user s)
        {
            var E_hoten = collection["Name"];
            var E_username = collection["Username"];
            var E_password = collection["Password"];
            var E_type = collection["Type"];
            if (string.IsNullOrEmpty(E_hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.name = E_hoten.ToString();
                s.username = E_username.ToString();
                s.password = E_password;
                if (E_type == "Admin")
                {
                    s.type = 1;
                }
                else if (E_type == "Staff")
                {
                    s.type = 0;
                }
               
                data.users.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("MangeUser");
            }
            return this.Create();
        }

        public ActionResult Edit(int id)
        {
            var E_user = data.users.First(m => m.id == id);
            return View(E_user);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_user = data.users.First(m => m.id == id);
            var E_hoten = collection["Name"];
            var E_username = collection["Username"];
            var E_password = collection["Password"];
            var E_type = Convert.ToByte(collection["Type"]);
            E_user.id = id;
            if (string.IsNullOrEmpty(E_hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_user.name = E_hoten;
                E_user.username = E_username;
                E_user.password = E_password;
                E_user.type = E_type;
                UpdateModel(E_user);
                data.SubmitChanges();
                return RedirectToAction("MangeUser");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(int id)
        {
            var D_user = data.users.Where(m => m.id == id).First();
            data.users.DeleteOnSubmit(D_user);
            data.SubmitChanges();
            return RedirectToAction("MangeUser");
        }
    }
}