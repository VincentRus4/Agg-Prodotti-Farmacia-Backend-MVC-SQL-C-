using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Farmasia.Models
{
    public class Sharedclass
    {
        public static SqlDataReader SelectFromDB(String SelectQuery)
        {
         string connectionstring = ConfigurationManager.ConnectionStrings["ModelDbContext"].ConnectionString;
            SqlConnection connessione = new SqlConnection(connectionstring);
            try
            {
                connessione.Open();
                SqlCommand comand = new SqlCommand(SelectQuery, connessione);
                SqlDataReader reader = comand.ExecuteReader();
                return reader;


            }
            catch
            {
                connessione.Close();
                return null;

            }
        }

    }
}