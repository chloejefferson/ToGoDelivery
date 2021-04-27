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

        // GET: OrderService
        public ActionResult Index()
        {
            return View(_db.OrderServices.ToList());
        }
    }
}