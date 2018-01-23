using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prism.Models;

namespace Prism.Controllers
{
    public class Consultants1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consultants1
        public async Task<ActionResult> Index()
        {
            var consultants = db.Consultants.Include(c => c.Grade);
            return View(await consultants.ToListAsync());
        }

        // GET: Consultants1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            return View(consultant);
        }

        // GET: Consultants1/Create
        public ActionResult Create()
        {
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "Name");
            return View();
        }

        // POST: Consultants1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ConsultantId,FirstName,LastName,GradeId,Email,ProjectId")] Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                db.Consultants.Add(consultant);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "Name", consultant.GradeId);
            return View(consultant);
        }

        // GET: Consultants1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "Name", consultant.GradeId);
            return View(consultant);
        }

        // POST: Consultants1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ConsultantId,FirstName,LastName,GradeId,Email,ProjectId")] Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultant).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "Name", consultant.GradeId);
            return View(consultant);
        }

        // GET: Consultants1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            return View(consultant);
        }

        // POST: Consultants1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Consultant consultant = await db.Consultants.FindAsync(id);
            db.Consultants.Remove(consultant);
            await db.SaveChangesAsync();
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
