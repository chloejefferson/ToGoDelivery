using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToGoDelivery.Data;
using ToGoDelivery.Models.Order;
using ToGoDelivery.Services;

namespace ToGoDelivery.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Order
        public ActionResult AdminIndex()
        {
            var svc = CreateOrderService();
            var model = svc.GetAllOrders();

            return View(model);
        }

        public ActionResult CustomerIndex()
        {
            var svc = CreateOrderService();
            var model = svc.GetOrdersByCustomer();

            return View(model);
        }

        public ActionResult CustomerCart()
        {
            var svc = CreateOrderService();
            //if (svc._currentOrderId != null)
            //{
                var model = svc.GetMostRecentOrder();
                return View(model);
            //}

            //return Create();
        }

        public ActionResult Create()
        {
            var svc = CreateOrderService();

            if (svc.CreateOrder())
            {
                TempData["SaveResult"] = "Your order was created.";
                return RedirectToAction("CustomerIndex");
            }

            ModelState.AddModelError("", "Order could not be created.");

            return RedirectToAction("CustomerIndex");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderById(id);

            return View(model);
        }

        //public ActionResult Edit(int id)
        //{
        //    var svc = CreateOrderService();
        //    var detail = svc.GetOrderById(id);
        //    var model =
        //        new OrderEdit
        //        {
        //            OrderId = detail.OrderId,
        //            Name = detail.Name,
        //            Cost = detail.Cost,
        //            Inventory = detail.Inventory
        //        };

        //    return View(model);
        //}

        //[HttpPost, ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, OrderEdit model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    if (model.OrderId != id)
        //    {
        //        ModelState.AddModelError("", "ID Mismatch");
        //        return View(model);
        //    };

        //    var svc = CreateOrderService();

        //    if (svc.UpdateOrder(model))
        //    {
        //        TempData["SaveResult"] = "Your order was updated.";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Your order could not be updated.");
        //    return View(model);
        //}

        [ActionName("SoftDelete")]
        public ActionResult SoftDelete(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderById(id);

            return View(model);
        }


        [ActionName("SoftDelete"), HttpPost, ValidateAntiForgeryToken]
        public ActionResult SoftDeletePost(int id)
        {
            var svc = CreateOrderService();

            svc.SoftDeleteOrder(id);

            TempData["SaveResult"] = "Your order was (soft) deleted.";

            return RedirectToAction("Index");

        }

        private Services.OrderService CreateOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new Services.OrderService(userId);
            return service;
        }
    }
}
