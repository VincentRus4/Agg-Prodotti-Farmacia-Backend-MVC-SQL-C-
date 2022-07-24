using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Farmasia.Models;


namespace Farmasia.Controllers
{
    public class TipoProdottoController : Controller
    {
        ModelDbContext context = new ModelDbContext();
        // GET: TipoProdotto
        public ActionResult Index()
        {
            List<TipoProdotto> prodotti = new List<TipoProdotto>();
            prodotti = context.TipoProdotto.ToList();
            return View(prodotti);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TipoProdotto p)
        {

            context.TipoProdotto.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");


        }

        

    }
}