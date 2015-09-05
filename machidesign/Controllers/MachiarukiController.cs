using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using matidesign.Models;

namespace matidesign.Controllers
{
    public class MachiarukiController : Controller
    {
        private machidesignDBContext db = new machidesignDBContext();

        // GET: Machiaruki
        public ActionResult Index()
        {
            return View(db.machiaruki.ToList());
        }

        // GET: Machiaruki/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machiaruki machiaruki = db.machiaruki.Find(id);
            if (machiaruki == null)
            {
                return HttpNotFound();
            }
            return View(machiaruki);
        }

        // GET: Machiaruki/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Machiaruki/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventsId,InsDate,UpdDate,InsAccountId,UpdAccountId,YukoFlg")] Machiaruki machiaruki)
        {
            if (ModelState.IsValid)
            {
                db.machiaruki.Add(machiaruki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(machiaruki);
        }

        // GET: Machiaruki/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machiaruki machiaruki = db.machiaruki.Find(id);
            if (machiaruki == null)
            {
                return HttpNotFound();
            }
            return View(machiaruki);
        }

        // POST: Machiaruki/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventsId,InsDate,UpdDate,InsAccountId,UpdAccountId,YukoFlg")] Machiaruki machiaruki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machiaruki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(machiaruki);
        }

        // GET: Machiaruki/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machiaruki machiaruki = db.machiaruki.Find(id);
            if (machiaruki == null)
            {
                return HttpNotFound();
            }
            return View(machiaruki);
        }

        // POST: Machiaruki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Machiaruki machiaruki = db.machiaruki.Find(id);
            db.machiaruki.Remove(machiaruki);
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
