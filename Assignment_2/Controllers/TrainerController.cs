using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_2.Models;

namespace Assignment_2.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index()
        {
            using(DbModels dbModels=new DbModels())
            {
            return View(dbModels.Trainers.ToList());
            }
        }

        // GET: Trainer/Details/5
        public ActionResult Details(int id)
        {
            using(DbModels dbModels=new DbModels())
            {
            return View(dbModels.Trainers.Where(x=>x.ID==id).FirstOrDefault());
            }
        }

        // GET: Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainer/Create
        [HttpPost]
        public ActionResult Create(Trainer trainer)
        {
            try
            {
                using(DbModels dbModels=new DbModels())
                {
                    dbModels.Trainers.Add(trainer);
                    dbModels.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Trainers.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Trainer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Trainer trainer)
        {
            try
            {
                using(DbModels dbModels=new DbModels())
                {
                    dbModels.Entry(trainer).State = EntityState.Modified;
                    dbModels.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trainer/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Trainers.Where(x => x.ID == id).FirstOrDefault());
            }
            
        }

        // POST: Trainer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using(DbModels dbModels=new DbModels())
                {
                    Trainer trainer = dbModels.Trainers.Where(x => x.ID == id).FirstOrDefault();
                    dbModels.Trainers.Remove(trainer);
                    dbModels.SaveChanges();
                }
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
