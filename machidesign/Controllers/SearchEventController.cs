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
    public class SearchEventController : Controller
    {
        private machidesignDBContext db = new machidesignDBContext();

        // GET: SearchEvent
        public ActionResult Index()
        {
            return View();
        }
        

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SearchEventView()
        {


            return View();
        }


        // GET: SearchEvent

        public ActionResult SearchEventView(string keyword, bool? YukoFlg)
        {
            
            // デフォルトではすべてのデータを取得
            var articles = from a in db.events
                           select a;
            //［キーワード］欄が空でない場合、その値で部分一致検索

            if (!string.IsNullOrEmpty(keyword))
            {
                articles = articles.Where(a => a.EventName.Contains(keyword));
            }

            //［公開済］チェックが付いている場合、公開済みの記事だけを絞り込み

            /*
            if (YukoFlg.HasValue && YukoFlg.Value)
            {
                articles = articles.Where(a => a.YukoFlg);
            }
             */


            return View(articles.ToList());
        }


        // GET: SearchEvent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SearchEvent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchEvent/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchEvent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SearchEvent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchEvent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SearchEvent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
