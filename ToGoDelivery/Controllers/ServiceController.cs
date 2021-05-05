using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToGoDelivery.Data;
using ToGoDelivery.Models.Service;
using ToGoDelivery.Services;

namespace ToGoDelivery.Controllers
{
    public class ServiceController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Service
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceService(userId);
            var model = service.GetServices();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ServiceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateServiceService();

            if (service.CreateService(model))
            {
                TempData["SaveResult"] = "Your service was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Service could not be created.");

            return View(model);

        }

        private ServiceService CreateServiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new ServiceService(userId);
            return svc;
        }
    }
}