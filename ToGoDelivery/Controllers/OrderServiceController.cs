using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToGoDelivery.Data;
using ToGoDelivery.Models;

namespace ToGoDelivery.Controllers
{
    public class OrderServiceController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult Create(int serviceId)
        {
            var svc = CreateOrderServiceService();
            int orderId = svc.GetCurrentOrderId();

            if (!svc.CheckForCurrentOrderService(orderId, serviceId))
            {
                if (svc.CreateOrderService(orderId, serviceId))
                {
                    TempData["SaveResult"] = "Service was added to your cart.";
                    return RedirectToAction("Index", "Menu");
                }

                ModelState.AddModelError("", "Service could not be added to your order. Have you started a new order?");

                return RedirectToAction("Index", "Menu");
            }

            TempData["SaveResult"] = "You already have this service in your cart.";
            return RedirectToAction("Index", "Menu");
        }

        //public ActionResult GetOrderServices(int orderId) //might not need this at all? I'm pulling order details from the orderdetail
        //{
        //    var svc = CreateOrderServiceService();
        //    ViewBag.OrderServices = svc.GetOrderServicesByOrderId(orderId);

        //    return ViewBag.OrderServices;//View(model); //This might need to be packaged differently since there is no view... may need to make an IEnumerable instead of action???
        //}


        public ActionResult Delete(int serviceId)
        {
            var svc = CreateOrderServiceService();
            int orderId = svc.GetCurrentOrderId();

            if (svc.DeleteOrderService(orderId, serviceId))
            {
                TempData["SaveResult"] = "Service was removed from your cart.";
                return RedirectToAction("CustomerCart", "Order");
            }

            ModelState.AddModelError("", "Service could not be removed from your cart.");

            return RedirectToAction("CustomerCart", "Order");
        }

        private Services.OrderServiceService CreateOrderServiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new Services.OrderServiceService(userId);
            return service;
        }

    }
}
