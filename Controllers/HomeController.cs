using Case_Study.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace Case_Study.Controllers
{
    public class HomeController : Controller
    {
        Database1Entities1 db = new Database1Entities1();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login log)
        {
            var user=db.Login.Where(x => x.username == log.username && x.password == log.password).Count();
            if (user>0)
            {
                return RedirectToAction("Index", "Bitkilers");
            }
            else
            {
                TempData["AlertMessage"] = "Kullanıcı adı veya  şifre yanlış! Lütfen tekrar yeniden deneyin.";
                return View();
            }
        }
    }
}