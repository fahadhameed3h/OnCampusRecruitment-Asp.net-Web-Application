using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnCampusRecruitment.DAL;
using OnCampusRecruitment.Models;
using Microsoft.AspNet.Identity;
using OnCampusRecruitment.CustomFilters;

namespace OnCampusRecruitment.Controllers
{
    [AuthLog(Roles = "student")]
    public class WorkExperienceController : Controller
    {
        private RecruitDB db = new RecruitDB();

        // GET: WorkExperience
        public ActionResult Index()
        {
            string CurrentUser = User.Identity.GetUserId();
            if (db.EmpProfiles.Where(r => r.UserID == CurrentUser).FirstOrDefault() == null)
            {
                return RedirectToAction("Create", "Profile");
            }
            else
            {
                int empProfileID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;
                var empWorkExperience = db.EmpWorkExperiences.Where(r => r.EmpProfileID == empProfileID);
                return View(empWorkExperience.ToList());
            }             
        }

        // GET: WorkExperience/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpWorkExperience empWorkExperience = db.EmpWorkExperiences.Find(id);
            if (empWorkExperience == null)
            {
                return HttpNotFound();
            }
            return View(empWorkExperience);
        }

        // GET: WorkExperience/Create
        public ActionResult Create()
        {
            string CurrentUser = User.Identity.GetUserId();
            int CurrentUserProfileID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;
            ViewBag.EmpProfileID = CurrentUserProfileID;
            return View();            
        }

        // POST: WorkExperience/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpWorkExperienceID,ExperienceType,JobTitle,Category,Company,StartDate,EndDate,Current,Salary,EmpProfileID")] EmpWorkExperience empWorkExperience)
        {
            if (ModelState.IsValid)
            {
                db.EmpWorkExperiences.Add(empWorkExperience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "FirstName", empWorkExperience.EmpProfileID);
            return View(empWorkExperience);
        }

        // GET: WorkExperience/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpWorkExperience empWorkExperience = db.EmpWorkExperiences.Find(id);
            if (empWorkExperience == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "FirstName", empWorkExperience.EmpProfileID);
            return View(empWorkExperience);
        }

        // POST: WorkExperience/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpWorkExperienceID,ExperienceType,JobTitle,Category,Company,StartDate,EndDate,Current,Salary,EmpProfileID")] EmpWorkExperience empWorkExperience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empWorkExperience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "FirstName", empWorkExperience.EmpProfileID);
            return View(empWorkExperience);
        }

        // GET: WorkExperience/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpWorkExperience empWorkExperience = db.EmpWorkExperiences.Find(id);
            if (empWorkExperience == null)
            {
                return HttpNotFound();
            }
            return View(empWorkExperience);
        }

        // POST: WorkExperience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpWorkExperience empWorkExperience = db.EmpWorkExperiences.Find(id);
            db.EmpWorkExperiences.Remove(empWorkExperience);
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
