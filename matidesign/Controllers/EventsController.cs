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
    public class EventsController : Controller
    {
        private machidesignDBContext db = new machidesignDBContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.events.Include(e => e.Jichitai);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ////LINQで並び替えて取得
            //var rows = db.group.ToList()
            //    .OrderBy(r => r.GroupName);

            ////ドロップダウンリストの配列を定義
            //List<SelectListItem> selItem = new List<SelectListItem>();

            ////取得したデータを配列に格納
            //foreach (var r in rows)
            //{
            //    selItem.Add(new SelectListItem() { Value = r.GroupId.ToString(), Text = r.GroupName });
            //}
            ////Viewへ値を渡す
            //ViewBag.GroupId = selItem;

            ////Viewへ値を渡す
            //return View();


            //LINQで並び替えて取得
            var rows = db.group.ToList()
                .OrderBy(r => r.GroupName);

            //ドロップダウンリストの配列を定義
            var group = new List<Group>();

            //取得したデータを配列に格納
            foreach (var r in rows)
            {
                group.Add(new Group() { GroupId = r.GroupId, GroupName = r.GroupName });
            }
            //Viewへ値を渡す
            ViewBag.Group = new SelectList(group, "GroupId", "GroupName");

            //Viewへ値を渡す
            return View();
        
        }

        // POST: Events/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventsId,InsDate,UpdDate,InsAccountId,UpdAccountId,YukoFlg,JichitaiId,GroupId,EventName,KaisaiDate_Start,KaisaiTime_Start,KaisaiDate_End,KaisaiTime_End,EventDescription,EventDetails,MaxNinzu")] Events events)
        {

            //作成日時セット
            events.InsDate = DateTime.Now;
            //更新日時セット
            events.UpdDate = DateTime.Now;
            //有効フラグセット
            events.YukoFlg = "1";

            //エラーをクリア
            ModelState.Remove("YukoFlg");                
            if (ModelState.IsValid)
            {
                db.events.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.JichitaiId = new SelectList(db.jichitai, "JichitaiId", "InsAccountId", events.JichitaiId);
            return View(events);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            ViewBag.JichitaiId = new SelectList(db.jichitai, "JichitaiId", "InsAccountId", events.JichitaiId);
            return View(events);
        }

        // POST: Events/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventsId,InsDate,UpdDate,InsAccountId,UpdAccountId,YukoFlg,JichitaiId,GroupId,EventName,KaisaiDate_Start,KaisaiTime_Start,KaisaiDate_End,KaisaiTime_End,EventDescription,EventDetails,MaxNinzu")] Events events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JichitaiId = new SelectList(db.jichitai, "JichitaiId", "InsAccountId", events.JichitaiId);
            return View(events);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Events events = db.events.Find(id);
            db.events.Remove(events);
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
