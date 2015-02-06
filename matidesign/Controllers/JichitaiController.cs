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
    public class JichitaiController : Controller
    {
        private machidesignDBContext db = new machidesignDBContext();

        // GET: jichitai
        public ActionResult Index()
        {
            return View(db.jichitai.ToList());
        }

        // GET: jichitai/Details/5
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

        // GET: jichitai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: jichitai/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JichitaiId,InsDate,UpdDate,YukoFlg,JichitaiName")] Jichitai jichitai)
        {
            //キー存在チェック
            if (CheckJichitaiId(jichitai.JichitaiId) == true)
            {
                ModelState.AddModelError("JichitaiId","既に存在するデータです。");
                return View(jichitai);
            }

            //作成日時セット
            jichitai.InsDate = DateTime.Now;
            //更新日時セット
            jichitai.UpdDate = DateTime.Now;
            //有効フラグセット
            jichitai.YukoFlg = "1";

            //エラーをクリア
            ModelState.Remove("YukoFlg");

            if (ModelState.IsValid)
            {
                db.jichitai.Add(jichitai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jichitai);
        }

        // GET: jichitai/Edit/5
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

        // POST: jichitai/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JichitaiId,InsDate,UpdDate,YukoFlg,JichitaiName")] Jichitai jichitai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jichitai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jichitai);
        }

        // GET: jichitai/Delete/5
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

        // POST: jichitai/Delete/5
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


        /// <summary>
        /// 主キー重複チェックを実行する・取得する
        /// </summary>
        /// <param name="JichitaiId">自治体コードを表す文字列</param>
        /// <returns></returns>
        public bool CheckJichitaiId(string JichitaiId)
        {
            // JSON 形式で true か false を返す
            Jichitai jichitai = db.jichitai.Find(JichitaiId);

            if (jichitai == null)
            {
                return false;
            }
            else {
                return true;
            }
        }
    
    }
}
