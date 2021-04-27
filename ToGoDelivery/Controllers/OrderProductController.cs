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

        // GET: OrderProduct
        public ActionResult Index()
        {
            return View(_db.OrderProducts.ToList());
        }
    }
}