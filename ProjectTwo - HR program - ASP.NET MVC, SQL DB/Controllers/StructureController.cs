using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Demo2._1.Models;

namespace Demo2._1.Controllers
{
    public class StructureController : Controller
    {
        private HRProManager db = new HRProManager();

        //Create a conections in aplication Home page

        //Create a conection with Details View
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees Edit 
        //Create a conection with Details View
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            if (employee.PositionID <= 4)
            {
                ViewBag.Manager = new SelectList(db.Employees.Where(e => e.PositionID == employee.PositionID - 1), "ID", "FullName", employee.Manager);
            }
            else
            {
                ViewBag.Manager = new SelectList(db.Employees.Where(e => e.PositionID == 4), "ID", "FullName", employee.Manager);
            }

            ViewBag.PositionID = new SelectList(db.Positions, "ID", "PositionName", employee.PositionID);
            ViewBag.ProjectID = new SelectList(db.ProjectNames, "ID", "Project", employee.ProjectID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        //Create a validation about Edit View
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FullName,Phone,Email,PositionID,ProjectID,Workplace,Salary,Manager")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Manager = new SelectList(db.Employees, "ID", "FullName", employee.Manager);
            ViewBag.PositionID = new SelectList(db.Positions, "ID", "PositionName", employee.PositionID);
            ViewBag.ProjectID = new SelectList(db.ProjectNames, "ID", "Project", employee.ProjectID);
            return View(employee);
        }

        
        // GET: Structure
        //Query for separate CEO
        [Authorize]
        public ActionResult CEO()
        {
            var employees = db.Employees.Include(e => e.Employee2)
                                        .Include(e => e.Position)
                                        .Include(e => e.ProjectName)
                                        .Where(p => p.Position.ID == 1);
            return View(employees.ToList());
        }

        //Query for separate Deliver Director
        [Authorize]
        public ActionResult DeliveryDirector()
        {
            var employees = db.Employees.Include(e => e.Employee2)
                                        .Include(e => e.Position)
                                        .Include(e => e.ProjectName)
                                        .Where(p => p.Position.ID == 2);
            return View(employees.ToList());
        }

        //Query for separate Project manager
        [Authorize]
        public ActionResult ProjectManager()
        {
            var employees = db.Employees.Include(e => e.Employee2)
                                        .Include(e => e.Position)
                                        .Include(e => e.ProjectName)
                                        .Where(p => p.Position.ID == 3);
            return View(employees.ToList());
        }

        //Query for separate Team lead
        [Authorize]
        public ActionResult TeamLead()
        {
            var employees = db.Employees.Include(e => e.Employee2)
                                        .Include(e => e.Position)
                                        .Include(e => e.ProjectName)
                                        .Where(p => p.Position.ID == 4);
            return View(employees.ToList());
        }

        //Query for separate all seniors
        [Authorize]
        public ActionResult Senior()
        {
            var employees = db.Employees.Include(e => e.Employee2)
                                        .Include(e => e.Position)
                                        .Include(e => e.ProjectName)
                                        .Where(p => p.Position.ID == 5);
            return View(employees.ToList());
        }

        //Query for separate all Intermediate
        [Authorize]
        public ActionResult Intermediate()
        {
            var employees = db.Employees.Include(e => e.Employee2)
                                        .Include(e => e.Position)
                                        .Include(e => e.ProjectName)
                                        .Where(p => p.Position.ID == 6);
            return View(employees.ToList());
        }

        //Query for separate all Juniors
        [Authorize]
        public ActionResult Junior()
        {
            var employees = db.Employees.Include(e => e.Employee2)
                                        .Include(e => e.Position)
                                        .Include(e => e.ProjectName)
                                        .Where(p => p.Position.ID == 7);
            return View(employees.ToList());
        }

        //Query for separate all Trainees
        [Authorize]
        public ActionResult Trainee()
        {
            var employees = db.Employees.Include(e => e.Employee2)
                                        .Include(e => e.Position)
                                        .Include(e => e.ProjectName)
                                        .Where(p => p.Position.ID == 8);
            return View(employees.ToList());
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        // POST: Employees Delete 
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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