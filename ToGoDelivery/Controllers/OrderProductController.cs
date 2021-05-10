using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToGoDelivery.Data;

namespace ToGoDelivery.Controllers
{
    public class OrderProductController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult Create(int productId)
        {
            var svc = CreateOrderProductService();
            int orderId = svc.GetCurrentOrderId();

            if (!svc.CheckForCurrentOrderProduct(orderId, productId))
            {
                if (svc.CreateOrderProduct(orderId, productId))
                {
                    TempData["SaveResult"] = "Product was added to your cart.";
                    return RedirectToAction("Index", "Menu");
                }

                ModelState.AddModelError("", "Product could not be added to your order. Have you started a new order?");

                return RedirectToAction("Index", "Menu");
            }

            return AddProductToOrderProduct(productId);
        }

        public ActionResult AddProductToOrderProduct(int productId)
        {
            var svc = CreateOrderProductService();
            int orderId = svc.GetCurrentOrderId();

            if(svc.AddProduct(orderId, productId))
            {
                TempData["SaveResult"] = "One more was added to your cart.";
                return RedirectToAction("Index", "Menu");
            }

            ModelState.AddModelError("", "Product could not be added to your order. Have you started a new order?");

            return RedirectToAction("Index", "Menu");
        }

        public ActionResult GetOrderProducts(int orderId) //might not need this at all? I'm pulling order details from the orderdetail
        {
            var svc = CreateOrderProductService();
            ViewBag.OrderProducts = svc.GetOrderProductsByOrderId(orderId);

            return ViewBag.OrderProducts;//View(model); //This might need to be packaged differently since there is no view... may need to make an IEnumerable instead of action???
        }

        private Services.OrderProductService CreateOrderProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new Services.OrderProductService(userId);
            return service;
        }

        public ActionResult Delete(int productId)
        {
            var svc = CreateOrderProductService();
            int orderId = svc.GetCurrentOrderId();

            if (svc.DeleteOrderProduct(orderId, productId))
            {
                TempData["SaveResult"] = "Product was removed from your cart.";
                return RedirectToAction("CustomerCart", "Order");
            }

            ModelState.AddModelError("", "Product could not be removed from your cart.");

            return RedirectToAction("CustomerCart", "Order");
        }

    }
}