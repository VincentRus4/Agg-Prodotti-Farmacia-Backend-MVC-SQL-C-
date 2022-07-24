using Farmasia.Models;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Farmasia.Controllers
{
    public class VenditaController : Controller
    {
        ModelDbContext context = new ModelDbContext();
        
        // GET: Vendita
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ModelDbContext"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM Prodotti", connection);

            SqlDataReader reader = comando.ExecuteReader();
            List<Vendite> prodotti = new List<Vendite>();
            prodotti = context.Vendite.ToList();
            if (reader.HasRows)
            {
                while (reader.Read())

                {
                    Vendite a = new Vendite();

                    a.Nome = Convert.ToString(reader["Nome"]);
                    a.Cognome = Convert.ToString(reader["Cognome"]);
                    a.Data = Convert.ToDateTime(reader["Data"]);
                    a.IdProdotto = Convert.ToInt32(reader["Prodotto"]);
                    prodotti.Add(a);
                }

            }
            connection.Close();
            return View(prodotti);
        }


        [HttpGet]
        public ActionResult Create()
        {
            string conn = ConfigurationManager.ConnectionStrings["ModelDbContext"].ToString();
            SqlConnection sqlconn = new SqlConnection(conn);
            sqlconn.Open();
            SqlCommand com = new SqlCommand("SELECT * FROM dbo.Prodotti", sqlconn);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                List<SelectListItem> List = new List<SelectListItem>();
                while (reader.Read())
                {
                    SelectListItem item = new SelectListItem();
                    item.Text = $"{ reader["Nome"]}";
                    item.Value = reader["IdProdotto"].ToString();
                    List.Add(item); 
                }
                ViewBag.ListaCombobox = List;

            }
            reader.Close();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Vendite a)
        {
            string conn = ConfigurationManager.ConnectionStrings["ModelDbContext"].ToString();
            SqlConnection sqlconn = new SqlConnection(conn);
            sqlconn.Open();
            SqlCommand comando = new SqlCommand(@"INSERT INTO Vendite(Nome,Cognome,IdProdotto,Data,IdTipo) VALUES 
                (@Nome,@Cognome,@IdProdotto,@Data,@IdTipo)", sqlconn);

            comando.Parameters.AddWithValue("Nome", a.Nome);
            comando.Parameters.AddWithValue("Cognome", a.Cognome);
            comando.Parameters.AddWithValue("IdProdotto", a.IdProdotto);
            comando.Parameters.AddWithValue("Data", a.Data);
            
            

            int risultato = comando.ExecuteNonQuery();
            sqlconn.Close();
            return RedirectToAction("Index");

        }
    }
}
