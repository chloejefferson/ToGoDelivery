using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToGoDelivery.Data;
using ToGoDelivery.Models;
using ToGoDelivery.Models.Product;
using ToGoDelivery.Services;

namespace ToGoDelivery.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            var model = service.GetProducts();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProductService();

            if (service.CreateProduct(model))
            {
                TempData["SaveResult"] = "Your product was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Product could not be created.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateProductService();
            var detail = svc.GetProductById(id);
            var model =
                new ProductEdit
                {
                    ProductId = detail.ProductId,
                    Name = detail.Name,
                    Cost = detail.Cost,
                    Inventory = detail.Inventory
                };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ProductId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            };

            var svc = CreateProductService();
            
            if(svc.UpdateProduct(model))
            {
                TempData["SaveResult"] = "Your product was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your product could not be updated.");
            return View(model);
        }

        [ActionName("SoftDelete")]
        public ActionResult SoftDelete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }


        [ActionName("SoftDelete"), HttpPost, ValidateAntiForgeryToken]
        public ActionResult SoftDeletePost(int id)
        {
            var svc = CreateProductService();
            
            svc.SoftDeleteProduct(id);

            TempData["SaveResult"] = "Your product was (soft) deleted.";

            return RedirectToAction("Index");

        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }
    }
}