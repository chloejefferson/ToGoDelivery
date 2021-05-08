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
        public ActionResult Details(int id)
        {
            var svc = CreateServiceService();
            var model = svc.GetServiceById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var svc = CreateServiceService();
            var detail = svc.GetServiceById(id);
            var model =
                new ServiceEdit
                {
                    ServiceId = detail.ServiceId,
                    Name = detail.Name,
                    Cost = detail.Cost,
                };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ServiceId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            };

            var svc = CreateServiceService();

            if (svc.UpdateService(model))
            {
                TempData["SaveResult"] = "Your Service was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Service could not be updated.");
            return View(model);
        }

        [ActionName("SoftDelete")]
        public ActionResult SoftDelete(int id)
        {
            var svc = CreateServiceService();
            var model = svc.GetServiceById(id);

            return View(model);
        }


        [ActionName("SoftDelete"), HttpPost, ValidateAntiForgeryToken]
        public ActionResult SoftDeletePost(int id)
        {
            var svc = CreateServiceService();

            svc.SoftDeleteService(id);

            TempData["SaveResult"] = "Your Service was (soft) deleted.";

            return RedirectToAction("Index");

        }

        private ServiceService CreateServiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new ServiceService(userId);
            return svc;
        }

    }
}