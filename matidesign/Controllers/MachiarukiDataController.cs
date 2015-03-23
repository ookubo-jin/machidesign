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
    public class MachiarukiDataController : Controller
    {
        private machidesignDBContext db = new machidesignDBContext();

        // GET: MachiarukiData
        public ActionResult Index()
        {
            var machiarukiDatas = db.MachiarukiDatas.Include(m => m.Account).Include(m => m.Events);
            return View(machiarukiDatas.ToList());
        }

        // GET: MachiarukiData/Details/5
        public ActionResult Details(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachiarukiData machiarukiData = db.MachiarukiDatas.Find(id);
            if (machiarukiData == null)
            {
                return HttpNotFound();
            }
            return View(machiarukiData);
        }

        // GET: MachiarukiData/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "InsAccountId");
            ViewBag.EventsId = new SelectList(db.events, "EventsId", "InsAccountId");
            return View();
        }

        // POST: MachiarukiData/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MachiarukiDataId,InsDate,UpdDate,InsAccountId,UpdAccountId,YukoFlg,EventsId,AccountId,Latitude,Longitude,Altitude,Accuracy,AltitudeAccuracy,Heading,Speed")] MachiarukiData machiarukiData)
        {
            if (ModelState.IsValid)
            {
                db.MachiarukiDatas.Add(machiarukiData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "InsAccountId", machiarukiData.AccountId);
            ViewBag.EventsId = new SelectList(db.events, "EventsId", "InsAccountId", machiarukiData.EventsId);
            return View(machiarukiData);
        }

        // GET: MachiarukiData/Edit/5
        public ActionResult Edit(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachiarukiData machiarukiData = db.MachiarukiDatas.Find(id);
            if (machiarukiData == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "InsAccountId", machiarukiData.AccountId);
            ViewBag.EventsId = new SelectList(db.events, "EventsId", "InsAccountId", machiarukiData.EventsId);
            return View(machiarukiData);
        }

        // POST: MachiarukiData/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MachiarukiDataId,InsDate,UpdDate,InsAccountId,UpdAccountId,YukoFlg,EventsId,AccountId,Latitude,Longitude,Altitude,Accuracy,AltitudeAccuracy,Heading,Speed")] MachiarukiData machiarukiData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machiarukiData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "InsAccountId", machiarukiData.AccountId);
            ViewBag.EventsId = new SelectList(db.events, "EventsId", "InsAccountId", machiarukiData.EventsId);
            return View(machiarukiData);
        }

        // GET: MachiarukiData/Delete/5
        public ActionResult Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachiarukiData machiarukiData = db.MachiarukiDatas.Find(id);
            if (machiarukiData == null)
            {
                return HttpNotFound();
            }
            return View(machiarukiData);
        }

        // POST: MachiarukiData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            MachiarukiData machiarukiData = db.MachiarukiDatas.Find(id);
            db.MachiarukiDatas.Remove(machiarukiData);
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
