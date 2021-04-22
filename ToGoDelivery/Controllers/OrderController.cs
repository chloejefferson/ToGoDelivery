using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToGoDelivery.Models;

namespace ToGoDelivery.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Order
        public ActionResult Index()
        {
            return View(_db.Orders.ToList());
        }
    }
}