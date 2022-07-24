using Farmasia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farmasia.Controllers
{
    public class DittaController : Controller
    {
        ModelDbContext context = new ModelDbContext();
        // GET: Ditta
        public ActionResult Index()
        {
            List<Ditta> ditta = new List<Ditta>();
            ditta = context.Ditta.ToList();
            return View(ditta);
        }
    }
}