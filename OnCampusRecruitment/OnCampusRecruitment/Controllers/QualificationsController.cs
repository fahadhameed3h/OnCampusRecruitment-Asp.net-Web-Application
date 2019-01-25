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

namespace OnCampusRecruitment.Controllers
{
    public class QualificationsController : Controller
    {
        private RecruitDB db = new RecruitDB();

        //public ActionResult Index()
        //{
        //    string CurrentUser = User.Identity.GetUserId();

        //    if (db.EmpProfiles.Where(r => r.UserID == CurrentUser).Any() == false)
        //    {
        //        return RedirectToAction("Create", "Profile");
        //    }
        //    else
        //    {
        //        int empProfileID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;
        //        var qualifications = db.Qualifications.Where(r => r.EmpProfileID == empProfileID);
        //        return View(qualifications.ToList());
        //    }         
        //}

        // GET: Qualifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // GET: Qualifications/Create

        public ActionResult Create()
        {
            string CurrentUser = User.Identity.GetUserId();
            int CurrentUserProfileID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;
            if (db.Qualifications.Where(r => r.EmpProfileID == CurrentUserProfileID).Any() == true)
            {
                return RedirectToAction("Edit", "Qualifications", new { id = CurrentUserProfileID });
            }
            else
            {
                ViewBag.EmpProfileID = CurrentUserProfileID;
                return View();
            }            
        }
              
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpProfileID,SchoolName,SchoolYearPassing,SchoolDegree,CollegeName,CollegeYearPassing,CollegeDegree,UniverstyName,DepartmentName,UniverstyYearPassing,GPA,Description")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                db.Qualifications.Add(qualification);
                db.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "UserID", qualification.EmpProfileID);
            return View(qualification);
        }

        // GET: Qualifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "UserID", qualification.EmpProfileID);
            return View(qualification);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpProfileID,SchoolName,SchoolYearPassing,SchoolDegree,CollegeName,CollegeYearPassing,CollegeDegree,UniverstyName,DepartmentName,UniverstyYearPassing,GPA,Description")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Dashboard");
            }
            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "UserID", qualification.EmpProfileID);
            //return View(qualification);
            return RedirectToAction("Index", "Dashboard");
        }

        // GET: Qualifications/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Qualification qualification = db.Qualifications.Find(id);
        //    if (qualification == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(qualification);
        //}

        // POST: Qualifications/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Qualification qualification = db.Qualifications.Find(id);
        //    db.Qualifications.Remove(qualification);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
