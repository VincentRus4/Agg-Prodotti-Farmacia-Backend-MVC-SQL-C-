using Farmasia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farmasia.Controllers
{
    public class HomeController : Controller
    {
        ModelDbContext context = new ModelDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
