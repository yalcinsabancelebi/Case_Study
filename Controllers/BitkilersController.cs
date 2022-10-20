using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Case_Study.Models;

namespace Case_Study.Controllers
{
    public class BitkilersController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Bitkilers
        public ActionResult Index()
        {
            return View(db.Bitkiler.ToList());
        }

        // GET: Bitkilers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitkiler bitkiler = db.Bitkiler.Find(id);
            if (bitkiler == null)
            {
                return HttpNotFound();
            }
            return View(bitkiler);
        }

        // GET: Bitkilers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bitkilers/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BitkiAdi,BitkiAciklamasi,BitkiFaydasi,BitkiResmi")] Bitkiler bitkiler)
        {
            if (ModelState.IsValid)
            {
                db.Bitkiler.Add(bitkiler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bitkiler);
        }

        // GET: Bitkilers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitkiler bitkiler = db.Bitkiler.Find(id);
            if (bitkiler == null)
            {
                return HttpNotFound();
            }
            return View(bitkiler);
        }

        // POST: Bitkilers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BitkiAdi,BitkiAciklamasi,BitkiFaydasi,BitkiResmi")] Bitkiler bitkiler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bitkiler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bitkiler);
        }

        // GET: Bitkilers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitkiler bitkiler = db.Bitkiler.Find(id);
            if (bitkiler == null)
            {
                return HttpNotFound();
            }
            return View(bitkiler);
        }

        //// POST: Bitkilers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Bitkiler bitkiler = db.Bitkiler.Find(id);
        //    db.Bitkiler.Remove(bitkiler);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpPost]
        public string Delete(int id)
        {
            try
            {
                Database1Entities1 db = new Database1Entities1();
                var bitkiler = db.Bitkiler.FirstOrDefault(x => x.Id == id);
                db.Bitkiler.Remove(bitkiler);
                db.SaveChanges();
                return "1";
            }
            catch (Exception)
            {
                return "-1";
            }

        }
    }
}
