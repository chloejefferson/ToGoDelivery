using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToGoDelivery.Data;

namespace ToGoDelivery.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Role
        public ActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            _db.Roles.Add(role);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}