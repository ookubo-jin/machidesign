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
    public class GroupController : Controller
    {
        private machidesignDBContext db = new machidesignDBContext();

        // GET: Group
        public ActionResult Index()
        {
            return View(db.group.ToList());
        }

        // GET: Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.group.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Group/Create
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

        // POST: Group/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,InsDate,UpdDate,YukoFlg,JichitaiId,GroupName,Email,HomePege,ImageUrl,GroupDescription")] Group group)
        {


            //作成日時セット
            group.InsDate = DateTime.Now;
            //更新日時セット
            group.UpdDate = DateTime.Now;
            //有効フラグセット
            group.YukoFlg = "1";

            //エラーをクリア
            ModelState.Remove("YukoFlg");            
            
            if (ModelState.IsValid)
            {
                db.group.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group);
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
            Group group = db.group.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Group/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,InsDate,UpdDate,YukoFlg,JichitaiId,GroupName,Email,HomePege,ImageUrl,GroupDescription")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.group.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.group.Find(id);
            db.group.Remove(group);
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
