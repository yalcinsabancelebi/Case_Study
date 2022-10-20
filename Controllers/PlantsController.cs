using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Case_Study.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace Case_Study.Controllers
{
    public class PlantsController : Controller
    {
        // GET: Plants
        public ActionResult Index()
        {
            
            string mainconn = ConfigurationManager.ConnectionStrings["Database1Entities0"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select*from Bitkiler";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<Plants> lplant = new List<Plants>();
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lplant.Add(new Plants
                {

                    BitkiAdi = Convert.ToString(dr["BitkiAdi"]),
                    BitkiAciklamasi = Convert.ToString(dr["BitkiAciklamasi"]),
                    BitkiFaydasi = Convert.ToString(dr["BitkiFaydasi"]),
                    BitkiResmi = Convert.ToString(dr["BitkiResmi"]),
                });
            }
            sqlconn.Close();
            ViewBag.BackgroundColor = "blue";
            return View(lplant);
        }
    }
}