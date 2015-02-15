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
    public class GroupsController : Controller
    {
        private machidesignDBContext db = new machidesignDBContext();

        // GET: Groups
        public ActionResult Index()
        {
            return View(db.groups.ToList());
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = db.groups.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            //LINQで並び替えて取得
            var rows = db.jichitai.ToList()
                .OrderBy(r => r.JichitaiId);

            //ドロップダウンリストの配列を定義
            List<SelectListItem> selItem= new List<SelectListItem>();

            //取得したデータを配列に格納
            foreach (var r in rows)
            {
                selItem.Add(new SelectListItem() { Value = r.JichitaiId, Text = r.JichitaiId + " " + r.JichitaiName });
            }

            //Viewへ値を渡す
            ViewBag.SelectOptions = selItem;

            return View();
        }

        // POST: Groups/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,InsDate,UpdDate,YukoFlg,JichitaiId,GroupName,Email,HomePege,ImageUrl,GroupDescription")] Groups groups)
        {


            //作成日時セット
            groups.InsDate = DateTime.Now;
            //更新日時セット
            groups.UpdDate = DateTime.Now;
            //有効フラグセット
            groups.YukoFlg = "1";

            //エラーをクリア
            ModelState.Remove("YukoFlg");            
            
            if (ModelState.IsValid)
            {
                db.groups.Add(groups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groups);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            //LINQで並び替えて取得
            var rows = db.jichitai.ToList()
                .OrderBy(r => r.JichitaiId);

            //ドロップダウンリストの配列を定義
            List<SelectListItem> selItem = new List<SelectListItem>();

            //取得したデータを配列に格納
            foreach (var r in rows)
            {
                selItem.Add(new SelectListItem() { Value = r.JichitaiId, Text = r.JichitaiId + " " + r.JichitaiName });
            }

            //Viewへ値を渡す
            ViewBag.SelectOptions = selItem;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = db.groups.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // POST: Groups/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,InsDate,UpdDate,YukoFlg,JichitaiId,GroupName,Email,HomePege,ImageUrl,GroupDescription")] Groups groups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groups);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = db.groups.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Groups groups = db.groups.Find(id);
            db.groups.Remove(groups);
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
