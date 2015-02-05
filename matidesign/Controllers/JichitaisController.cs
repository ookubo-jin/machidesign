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
    public class JichitaisController : Controller
    {
        private machidesignDBContext db = new machidesignDBContext();

        // GET: Jichitais
        public ActionResult Index()
        {
            return View(db.jichitai.ToList());
        }

        // GET: Jichitais/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jichitai jichitai = db.jichitai.Find(id);
            if (jichitai == null)
            {
                return HttpNotFound();
            }
            return View(jichitai);
        }

        // GET: Jichitais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jichitais/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JichitaiId,JichitaiCode,JichitaiName,SiyoFlg,InsDate,UpdDate")] Jichitai jichitai)
        {
            if (ModelState.IsValid)
            {
                db.jichitai.Add(jichitai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jichitai);
        }

        // GET: Jichitais/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jichitai jichitai = db.jichitai.Find(id);
            if (jichitai == null)
            {
                return HttpNotFound();
            }
            return View(jichitai);
        }

        // POST: Jichitais/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JichitaiId,JichitaiCode,JichitaiName,SiyoFlg,InsDate,UpdDate")] Jichitai jichitai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jichitai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jichitai);
        }

        // GET: Jichitais/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jichitai jichitai = db.jichitai.Find(id);
            if (jichitai == null)
            {
                return HttpNotFound();
            }
            return View(jichitai);
        }

        // POST: Jichitais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Jichitai jichitai = db.jichitai.Find(id);
            db.jichitai.Remove(jichitai);
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
