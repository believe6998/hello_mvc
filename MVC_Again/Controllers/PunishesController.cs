using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Again.Models;

namespace MVC_Again.Controllers
{
    public class PunishesController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: Punishes
        [Obsolete]
        public ActionResult Index()
        {
            var punishes = db.Punishes.Include(p => p.Student);
            return View(punishes.ToList());
        } 
        public ActionResult AjaxIndex(string startDate, string endDate)
        {
            var start = DateTime.Parse(startDate);
            var end = DateTime.Parse(endDate);
            var punishes = db.Punishes.Include(p => p.Student).Where(p => p.Date >= start).Where(p => p.Date <= end);
            return PartialView(punishes.ToList());
        }

        // GET: Punishes/Details/5
        public ActionResult Details(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punish punish = db.Punishes.Find(id);
            if (punish == null)
            {
                return HttpNotFound();
            }
            return View(punish);
        }

        // GET: Punishes/Create
        public ActionResult Create()
        {
            ViewBag.StudentRollNumber = new SelectList(db.Students, "RollNumber", "Name");
            return View();
        }

        // POST: Punishes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public ActionResult Create([Bind(Include = "Id,Money,pushUp,Date,StudentRollNumber")] Punish punish)
        {
            if (ModelState.IsValid)
            {
                var res = db.Punishes.Where(p=>p.StudentRollNumber == punish.StudentRollNumber && p.Date == punish.Date);
                if (res.Any())
                {
                    var currentPunish = res.First();
                    currentPunish.pushUp += punish.pushUp;
                    currentPunish.Money += punish.Money;
                }
                else
                {
                    db.Punishes.Add(punish);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentRollNumber = new SelectList(db.Students, "RollNumber", "Name", punish.StudentRollNumber);
            return View(punish);
        }

        // GET: Punishes/Edit/5
        public ActionResult Edit(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punish punish = db.Punishes.Find(id);
            if (punish == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentRollNumber = new SelectList(db.Students, "RollNumber", "Name", punish.StudentRollNumber);
            return View(punish);
        }

        // POST: Punishes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Money,pushUp,Date,StudentRollNumber")] Punish punish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(punish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentRollNumber = new SelectList(db.Students, "RollNumber", "Name", punish.StudentRollNumber);
            return View(punish);
        }

        // GET: Punishes/Delete/5
        public ActionResult Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punish punish = db.Punishes.Find(id);
            if (punish == null)
            {
                return HttpNotFound();
            }
            return View(punish);
        }

        // POST: Punishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            Punish punish = db.Punishes.Find(id);
            db.Punishes.Remove(punish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
