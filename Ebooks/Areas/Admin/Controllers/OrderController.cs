using Ebooks.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebooks.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        MyAdminDataDataContext data = new MyAdminDataDataContext();
        // GET: Admin/Order
        public ActionResult Orders()
        {
            var query = from o in data.orders
                        join c in data.customers on o.id_customer equals c.id
                        join ol in data.order_lists on o.id equals ol.id_order
                        group new { o, ol, c } by new {o.date_create, c.name,o.id, o.status } into g
                        select new OrderManage
                        {
                            Id_Orders = Convert.ToInt32(g.Key.id),
                            Date_create = Convert.ToDateTime(g.Key.date_create),
                            Customer_name = g.Key.name,
                            Status_order = Convert.ToByte(g.Key.status),
                            Amount_book = g.Sum(n => Convert.ToInt32(n.ol.amount)),
                            Total = g.Sum(x => Convert.ToDouble(x.ol.unit_price))
                        };
            ViewBag.OrderInfo = query;
            return View();
        }

        public ActionResult ManageOrder(int id)
        {
            var query = from ol in data.order_lists
                        join o in data.orders on ol.id_order equals o.id
                        join b in data.Books on ol.id_book equals b.id
                        join c in data.customers on o.id_customer equals c.id
                        where o.id == id
                        select new BookOrder
                        {
                            Book_image = b.image_path,
                            Book_name = b.title,
                            Book_author = b.author,
                            Book_price = Convert.ToDouble(b.price),
                            Book_qty = Convert.ToInt32(ol.amount),
                            Book_total = Convert.ToDouble(ol.unit_price)
                        };
            var query1 = from o in data.orders
                        join c in data.customers on o.id_customer equals c.id
                        join ol in data.order_lists on o.id equals ol.id_order
                        where o.id == id
                        group new { o, ol, c } by new { o.id, c.name, c.address, c.contact, o.status } into g
                        select new CustomerOrders
                        {
                            Customer_orderID = g.Key.id,
                            Customer_name = g.Key.name,
                            Customer_addr = g.Key.address,
                            Customer_phone = g.Key.contact,
                            Customer_total = g.Sum(n => Convert.ToDouble(n.ol.unit_price)),
                            Customer_status = Convert.ToByte(g.Key.status)
                        };
            ViewBag.CustomerInfo = query1;
            ViewBag.BookOrder = query;
            return View();
        }

        public ActionResult ChangeStatus(int id)
        {
            var E_order = data.orders.First(m => m.id == id);
            E_order.id = id;
            if (E_order.status == false)
            {
                E_order.status = true;
                UpdateModel(E_order);
                data.SubmitChanges();
                return RedirectToAction("Orders");
            }
            else
            {
                E_order.status = false;
                UpdateModel(E_order);
                data.SubmitChanges();
                return RedirectToAction("Orders");
            }
        }


        //-----------------------------------------

        public ActionResult DeleteOrder(int id)
        {
            var O_order = data.orders.Where(m => m.id == id).First();
            var OL_orderlist = data.order_lists.Where(n => n.id_order == id).First();
            data.orders.DeleteOnSubmit(O_order);
            data.order_lists.DeleteOnSubmit(OL_orderlist);
            data.SubmitChanges();
            return RedirectToAction("Orders");
        }
    }
}