using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Demo2._1.Models;
using System.Collections.Generic;

namespace Demo2._1.Controllers
{
    public class ProjectNamesController : Controller
    {
        private HRProManager db = new HRProManager();

        // GET: ProjectNames
        //Create an action about Projects 
        

        //Create a conection between ProjectName.db and Index View
        [Authorize]
        public ActionResult Index()
        {
            return View(db.ProjectNames.ToList());
        }

       
        public ActionResult Team(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProjectName projectName = db.ProjectNames.Find(id);

            if (projectName == null)
            {
                return HttpNotFound();
            }

            //Create a query to take employees full name from db.Employees
            var query = (from m in db.Employees
                         where m.ProjectID == projectName.ID
                         select new { m.FullName});

            var members = new List<Employee>();

            foreach (var item in query)
            {
                members.Add(new Employee() { FullName = item.FullName });
            }

            return View(members);            
        }





        // GET: ProjectNames Details 
        //Create a conection between ProjectName.db and Details View
        [Authorize]
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectName projectName = db.ProjectNames.Find(id);
            if (projectName == null)
            {
                return HttpNotFound();
            }          

            return View(projectName);
        }

        // GET: ProjectNames Create
        
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ManagerID = new SelectList(db.Employees.Where(e => e.PositionID == 3), "ID", "FullName");
            return View();
        }

        // POST: ProjectNames Create
        //Create a new Project
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Project,ManagerID")] ProjectName projectName)
        {
            if (ModelState.IsValid)
            {
                db.ProjectNames.Add(projectName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerID = new SelectList(db.Employees.Where(e => e.PositionID == 3), "ID", "FullName", projectName.ManagerID);
            return View(projectName);
        }

        // GET: ProjectNames Edit
        //Edite a project
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectName projectName = db.ProjectNames.Find(id);
            if (projectName == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerID = new SelectList(db.Employees.Where(e => e.PositionID == 3), "ID", "FullName", projectName.ManagerID);
            return View(projectName);
        }

        // POST: ProjectNames Edit       
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Project,ManagerID")] ProjectName projectName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.ManagerID = new SelectList(db.Employees.Where(e =>e.PositionID == 3), "ID", "FullName", projectName.ManagerID);
            return View(projectName);
        }

        // GET: ProjectNames Delete         
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectName projectName = db.ProjectNames.Find(id);
            if (projectName == null)
            {
                return HttpNotFound();
            }
            return View(projectName);
        }

        // POST: ProjectNames Delete 
        //Delete a project
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectName projectName = db.ProjectNames.Find(id);
            db.ProjectNames.Remove(projectName);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Create a Dispose method
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
