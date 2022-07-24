using Farmasia.Models;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farmasia.Controllers
{
    public class ProdottiController : Controller
    {
        ModelDbContext context = new ModelDbContext();
        // GET: Prodotti
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ModelDbContext"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM Prodotti", connection);

            SqlDataReader reader = comando.ExecuteReader();
            List<Prodotti> prodotti = new List<Prodotti>();
            prodotti = context.Prodotti.ToList();
            if (reader.HasRows)
            {
                while (reader.Read())

                {
                    Prodotti a = new Prodotti();

                    a.Nome = Convert.ToString(reader["Nome"]);
                    a.Armadietto = Convert.ToString(reader["Armadietto"]);
                    a.IdTipo = Convert.ToInt32(reader["IdTipo"]);
                    a.Cassetto = Convert.ToString(reader["Cassetto"]);
                    a.Ditta = Convert.ToString(reader["Ditta"]);
                    prodotti.Add(a);
                }

            }
            connection.Close();
            return View(prodotti);

        }
        [HttpGet]
        public ActionResult Create()
        {

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "",Value="0" });

            items.Add(new SelectListItem { Text = "Profumeria", Value = "1" });

            items.Add(new SelectListItem { Text = "Medicinale", Value = "2", Selected = true });

            ViewBag.Productype = items;

            return View();

        }
        [HttpPost]
        public ActionResult Create(Prodotti a)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ModelDbContext"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand comando = new SqlCommand(@"INSERT INTO Prodotti(Nome,Dettagli,Ditta,Armadietto,IdTipo,Cassetto) VALUES 
                (@Nome,@Dettagli,@Ditta,@Armadietto,@IdTipo,@Cassetto)", connection);
            
            comando.Parameters.AddWithValue("Nome", a.Nome);
            comando.Parameters.AddWithValue("Dettagli", a.Dettagli);
            comando.Parameters.AddWithValue("Ditta", a.Ditta);
            comando.Parameters.AddWithValue("Armadietto", a.Armadietto);
            comando.Parameters.AddWithValue("IdTipo", a.IdTipo);
            comando.Parameters.AddWithValue("Cassetto", a.Cassetto);

            int risultato = comando.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Prodotti p = new Prodotti();
            p = context.Prodotti.Find(id);
            ViewBag.ListaTipo = context.TipoProdotto.ToList();




            return View();


        }
        [HttpPost]
        public ActionResult Edit(Prodotti p)
        {
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            Prodotti p = new Prodotti();
            p = context.Prodotti.Find(id);
            return View();

        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfDelete(int id)
        {
            Prodotti p = new Prodotti();
            p = context.Prodotti.Find(id);
            context.Prodotti.Remove(p);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}