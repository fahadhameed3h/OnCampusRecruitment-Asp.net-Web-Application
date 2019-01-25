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
using OnCampusRecruitment.CustomFilters;
using Microsoft.AspNet.Identity;

namespace OnCampusRecruitment.Controllers
{
    
    public class ApplyController : Controller
    {
        private RecruitDB db = new RecruitDB();

        // GET: Apply
        public ActionResult Index()
        {
            var jobApplications = db.JobApplications.Include(j => j.CompanyJobPost).Include(j => j.EmpProfile);
            return View(jobApplications.ToList());
        }

        [AuthLog(Roles = "student")]
        public ActionResult AppliedJobs()
        {
            string CurrentUser = User.Identity.GetUserId();
            int CurrentEmpProfileID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;            

            var jobApplications = db.JobApplications.Include(j => j.CompanyJobPost).Include(j => j.EmpProfile).Where(r=>r.EmpProfileID == CurrentEmpProfileID);
            return View(jobApplications.ToList());
        }

        [AuthLog(Roles = "company")]
        public ActionResult JobApplication()
        {
            string CurrentUser = User.Identity.GetUserId();
            int CurrentCompanyProfileID = db.CompanyProfiles.Where(r => r.UserID == CurrentUser).First().CompanyProfileID;
            

            var jobApplications = db.JobApplications.Include(j => j.CompanyJobPost).Include(j => j.EmpProfile).Where(r => r.CompanyJobPost.CompanyProfileID == CurrentCompanyProfileID);
            return View(jobApplications.ToList());
        }


        // GET: Apply/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return HttpNotFound();
            }
            return View(jobApplication);
        }

        // GET: Apply/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string CurrentUser = User.Identity.GetUserId();
            if (db.EmpProfiles.Where(r => r.UserID == CurrentUser).Any() == false)
            {
                return RedirectToAction("Create", "Profile");
            }
           
            int CurrentUserProfileID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;
            ViewBag.EmpProfileID = CurrentUserProfileID;            
            ViewBag.CompanyJobPostID = id;

            return View();
        }      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyJobPostID,EmpProfileID")] JobApplication jobApplication)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.JobApplications.Add(jobApplication);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception ex)
            {
                return View("DuplicateJobApplication", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
            ViewBag.CompanyJobPostID = jobApplication.CompanyJobPostID;
            ViewBag.EmpProfileID = jobApplication.EmpProfileID;
          
            return View(jobApplication);
        }

        // GET: Apply/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyJobPostID = new SelectList(db.CompanyJobPosts, "CompanyJobPostID", "JobDescription", jobApplication.CompanyJobPostID);
            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "UserID", jobApplication.EmpProfileID);
            return View(jobApplication);
        }

        // POST: Apply/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyJobPostID,EmpProfileID")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyJobPostID = new SelectList(db.CompanyJobPosts, "CompanyJobPostID", "JobDescription", jobApplication.CompanyJobPostID);
            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "UserID", jobApplication.EmpProfileID);
            return View(jobApplication);
        }

        // GET: Apply/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return HttpNotFound();
            }
            return View(jobApplication);
        }

        // POST: Apply/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobApplication jobApplication = db.JobApplications.Find(id);
            db.JobApplications.Remove(jobApplication);
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
