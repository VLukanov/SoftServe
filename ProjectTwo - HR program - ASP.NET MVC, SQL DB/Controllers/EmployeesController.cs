using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Demo2._1.Models;

namespace Demo2._1.Controllers
{
    public class EmployeesController : Controller
    {
        private HRProManager db = new HRProManager();

        // GET: Read Employees from DB
        [Authorize]
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Employee2).Include(e => e.Position).Include(e => e.ProjectName);
            return View(employees.ToList());
        }

        // GET: Employees Details
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

        // GET: Employees Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Manager = new SelectList(db.Employees, "ID", "FullName");
            ViewBag.PositionID = new SelectList(db.Positions, "ID", "PositionName");
            ViewBag.ProjectID = new SelectList(db.ProjectNames, "ID", "Project");
            return View();
        }

        // POST: Employees Create
        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FullName,Phone,Email,PositionID,ProjectID,Workplace,Salary,Manager")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
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

        // GET: Employees Edit
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

        // POST: Employees Edit
        
        [HttpPost]
        [Authorize]
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

        // GET: Employees Delete
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
