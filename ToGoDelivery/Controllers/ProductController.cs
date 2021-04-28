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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);

            service.CreateProduct(model);

            return RedirectToAction("Index");

        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Product product = _db.Products.Find(id);
            
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult Delete (int id)
        {
            Product product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Product product = _db.Products.Find(id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [HttpPost, ActionName("Edit"), ValidateAntiForgeryToken]
        public ActionResult Edit (Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Product product = _db.Products.Find(id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }
    }
}