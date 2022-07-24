using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using Farmasia.Models;

namespace Farmasia.Controllers
{
    public class JsonController : Controller
    {
        DateTime DataInserita;
        ModelDbContext context = new ModelDbContext();

        // GET: Json
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ElencoMedicinali()
        {
            string conn = ConfigurationManager.ConnectionStrings["ModelDbcontext"].ToString();
            SqlConnection sqlconn = new SqlConnection(conn);
            sqlconn.Open();
            SqlCommand commm = new SqlCommand($"SELECT IdProdotto as Prodotti FROM Vendite WHERE Data LIKE{DataInserita}");
            SqlDataReader reader = commm.ExecuteReader();
            List<Prodotti> Listam = new List<Prodotti>();
            Listam = context.Prodotti.ToList();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Prodotti a = new Prodotti();

                    a.Nome = Convert.ToString(reader["Nome"]);
                }
            }
            return Json(DataInserita ,JsonRequestBehavior.AllowGet);
        }
    }
}