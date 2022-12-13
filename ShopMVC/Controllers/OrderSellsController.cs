using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopMVC.Models;

namespace ShopMVC.Controllers
{
    public class OrderSellsController : Controller
    {
        private GoodsMgntEntities db = new GoodsMgntEntities();

        // GET: OrderSells
        public ActionResult Index()
        {
            return View(db.OrderSells.ToList());
        }

        // GET: OrderSells/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderSell orderSell = db.OrderSells.Find(id);
            if (orderSell == null)
            {
                return HttpNotFound();
            }
            return View(orderSell);
        }

        // GET: OrderSells/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderSells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderID,orderDate,agentID,paymentMethod,orderItem,orderItemAmount,orderPrice")] OrderSell orderSell)
        {
            if (ModelState.IsValid)
            {
                db.OrderSells.Add(orderSell);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderSell);
        }

        // GET: OrderSells/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderSell orderSell = db.OrderSells.Find(id);
            if (orderSell == null)
            {
                return HttpNotFound();
            }
            return View(orderSell);
        }

        // POST: OrderSells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderID,orderDate,agentID,paymentMethod,orderItem,orderItemAmount,orderPrice")] OrderSell orderSell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderSell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderSell);
        }

        // GET: OrderSells/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderSell orderSell = db.OrderSells.Find(id);
            if (orderSell == null)
            {
                return HttpNotFound();
            }
            return View(orderSell);
        }

        // POST: OrderSells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            OrderSell orderSell = db.OrderSells.Find(id);
            db.OrderSells.Remove(orderSell);
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
