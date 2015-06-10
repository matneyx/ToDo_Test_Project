/*  All the methods within this controller were created when the Controller was added.
    Because it was unused, I removed anything to do with a Details page (including the Details View),
    but this is otherwise untouched.  */


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo_Test_Project.Models;

namespace ToDo_Test_Project.Controllers
{ 
    public class ToDoController : Controller
    {
        private ToDoDBContext db = new ToDoDBContext();

        

        public ViewResult Index()
        {   /* This is called whenever the view returns to Index.
             * It doesn't do anything fancy -- simply lists the DB records as they lie.  */
            
            return View(db.ToDo.ToList());
        }

        //
       

        //
        // GET: /ToDo/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ToDo/Create

        [HttpPost]
        public ActionResult Create(ToDoDB tododb)
        {
            if (ModelState.IsValid)
            {
                db.ToDo.Add(tododb);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tododb);
        }
        
        //
        // GET: /ToDo/Edit/5
 
        public ActionResult Edit(int id)
        {
            ToDoDB tododb = db.ToDo.Find(id);
            return View(tododb);
        }

        //
        // POST: /ToDo/Edit/5

        [HttpPost]
        public ActionResult Edit(ToDoDB tododb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tododb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tododb);
        }

        //
        // GET: /ToDo/Delete/5
 
        public ActionResult Delete(int id)
        {
            ToDoDB tododb = db.ToDo.Find(id);
            return View(tododb);
        }

        //
        // POST: /ToDo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ToDoDB tododb = db.ToDo.Find(id);
            db.ToDo.Remove(tododb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}