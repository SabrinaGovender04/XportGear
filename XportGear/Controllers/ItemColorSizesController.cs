using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XportGear.Models;

namespace XportGear.Controllers
{
    public class ItemColorSizesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemColorSizes
        public ActionResult Index()
        {
            var itemColorSizes = db.ItemColorSizes.Include(i => i.Color).Include(i => i.Item).Include(i => i.Size);
            return View(itemColorSizes.ToList());
        }

        // GET: ItemColorSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemColorSize itemColorSize = db.ItemColorSizes.Find(id);
            if (itemColorSize == null)
            {
                return HttpNotFound();
            }
            return View(itemColorSize);
        }

        // GET: ItemColorSizes/Create
        public ActionResult Create()
        {
            ViewBag.ColorId = new SelectList(db.Colors, "SizeId", "ColorName");
            ViewBag.ItemCode = new SelectList(db.Items, "ItemCode", "Name");
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "Name");
            return View();
        }

        // POST: ItemColorSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SizeId,ColorId,Quantity,ItemCode")] ItemColorSize itemColorSize)
        {
          
            if (ModelState.IsValid)
            {
               
                //db.Items.SingleOrDefault(X => X.ItemCode == itemColorSize.ItemCode).QuantityInStock +=itemColorSize.Quantity;
                //db.Items.SingleOrDefault(X => X.ItemCode == itemColorSize.ItemCode).size += itemColorSize.Size;
                //db.Items.SingleOrDefault(X => X.ItemCode == itemColorSize.ItemCode).color += itemColorSize.Color;
                db.ItemColorSizes.Add(itemColorSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorId = new SelectList(db.Colors, "SizeId", "ColorName", itemColorSize.ColorId);
            ViewBag.ItemCode = new SelectList(db.Items, "ItemCode", "Name", itemColorSize.ItemCode);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "Name", itemColorSize.SizeId);
            return View(itemColorSize);
        }

        // GET: ItemColorSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemColorSize itemColorSize = db.ItemColorSizes.Find(id);
            if (itemColorSize == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorId = new SelectList(db.Colors, "SizeId", "ColorName", itemColorSize.ColorId);
            ViewBag.ItemCode = new SelectList(db.Items, "ItemCode", "Name", itemColorSize.ItemCode);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "Name", itemColorSize.SizeId);
            return View(itemColorSize);
        }

        // POST: ItemColorSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SizeId,ColorId,Quantity,ItemCode")] ItemColorSize itemColorSize)
        {
            if (ModelState.IsValid)
            {
                db.Items.SingleOrDefault(X => X.ItemCode == itemColorSize.ItemCode).QuantityInStock = +itemColorSize.Quantity;
                db.Entry(itemColorSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorId = new SelectList(db.Colors, "SizeId", "ColorName", itemColorSize.ColorId);
            ViewBag.ItemCode = new SelectList(db.Items, "ItemCode", "Name", itemColorSize.ItemCode);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "Name", itemColorSize.SizeId);
            return View(itemColorSize);
        }

        // GET: ItemColorSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemColorSize itemColorSize = db.ItemColorSizes.Find(id);
            if (itemColorSize == null)
            {
                return HttpNotFound();
            }
            return View(itemColorSize);
        }

        // POST: ItemColorSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemColorSize itemColorSize = db.ItemColorSizes.Find(id);
            db.ItemColorSizes.Remove(itemColorSize);
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
