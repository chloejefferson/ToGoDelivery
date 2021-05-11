using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToGoDelivery.Data;
using ToGoDelivery.Services;

namespace ToGoDelivery.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //This menu controller is meant to host both products and services in the views utilizing the product and service controllers and services
        // GET: Menu
        public ActionResult Index()
        {
            //var pctrl = new ProductController();
            //var psvc = pctrl.CreateProductService();
            //var pmodel = psvc.GetProducts();
            var psvc = CreateProductService();


            var sctrl = new ServiceController();
            //var ssvc = sctrl.CreateServiceService();
            //var smodel = ssvc.GetServices();
            var ssvc = CreateServiceService();

            //dynamic model = new ExpandoObject();
            //model.Products = psvc.GetProducts();
            //model.Services = ssvc.GetServices();
            ViewBag.Products = psvc.GetProducts();
            ViewBag.Services = ssvc.GetServices();

            //return View(model);
            return View();
        }
        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }
        private ServiceService CreateServiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new ServiceService(userId);
            return svc;
        }
    }
}