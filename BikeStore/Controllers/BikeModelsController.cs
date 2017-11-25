using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeStore.Models;
using BikeStore.DataAccess;

namespace BikeStore.Controllers
{
    public class BikeModelsController : Controller
    {
        private BikeContext db = new BikeContext();

        // GET: BikeModels
        public ActionResult Index()
        {
            return View(db.bikeRepository.findAll());
        }
      
        // GET: BikeModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeModel bikeModel = db.bikeRepository.findBike(id);
            if (bikeModel == null)
            {
                return HttpNotFound();
            }
            return View(bikeModel);
        }

        // GET: BikeModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BikeModels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BikeModelName,Mark,Price")] BikeModel bikeModel)
        {
            if (ModelState.IsValid)
            {
                db.bikeRepository.save(bikeModel);
                return RedirectToAction("Index");
            }

            return View(bikeModel);
        }

        // GET: BikeModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeModel bikeModel = db.bikeRepository.findBike(id);
            if (bikeModel == null)
            {
                return HttpNotFound();
            }
            return View(bikeModel);
        }

        // POST: BikeModels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BikeModelName,Mark,Price")] BikeModel bikeModel)
        {
            if (ModelState.IsValid)
            {
                db.bikeRepository.update(bikeModel);
                return RedirectToAction("Index");
            }
            return View(bikeModel);
        }

        // GET: BikeModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeModel bikeModel = db.bikeRepository.findBike(id);
            if (bikeModel == null)
            {
                return HttpNotFound();
            }
            return View(bikeModel);
        }

        // POST: BikeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BikeModel bikeModel = db.bikeRepository.findBike(id);
            db.bikeRepository.delete(bikeModel);
            return RedirectToAction("Index");
        }

        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        */
        
    }
}
