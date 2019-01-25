using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnCampusRecruitment.DAL;
using OnCampusRecruitment.Models;
using System;
using Microsoft.AspNet.Identity;
using System.IO;
using OnCampusRecruitment.CustomFilters;

namespace OnCampusRecruitment.Controllers
{    
    public class ProfileController : Controller
    {
        private RecruitDB db = new RecruitDB();

        [AuthLog(Roles = "admin")]
        public ActionResult Index()
        {
            string abc = User.Identity.GetUserId();
            return View(db.EmpProfiles.Where(r => r.UserID == abc).ToList());
        }

        [Authorize(Roles = "admin,company")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpProfile empProfile = db.EmpProfiles.Find(id);
            if (empProfile == null)
            {
                return HttpNotFound();
            }
            return PartialView(empProfile);
        }

        [AuthLog(Roles = "student")]
        public ActionResult Create()
        {
            string CurrentUser = User.Identity.GetUserId();
            if (db.EmpProfiles.Where(r => r.UserID == CurrentUser).Any() == true)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthLog(Roles = "student")]
        public ActionResult Create([Bind(Include = "EmpProfileID,FirstName,LastName,Gender,DOB,University,City,Nationality,CNIC,Contact,Address,UserID")] EmpProfile empProfile)
        {
            if (ModelState.IsValid)
            {               
                db.EmpProfiles.Add(empProfile);
                db.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }
            return View(empProfile);
        }

        [AuthLog(Roles = "student")]
        public ActionResult Edit()
        {
            string abc = User.Identity.GetUserId();
            int id = db.EmpProfiles.Where(r => r.UserID == abc).First().EmpProfileID;
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmpProfile empProfile = db.EmpProfiles.Find(id);
            if (empProfile == null)
            {
                return HttpNotFound();
            }
            return View(empProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthLog(Roles = "student")]
        public ActionResult Edit([Bind(Include = "EmpProfileID,FirstName,LastName,Gender,DOB,University,City,Nationality,CNIC,Contact,Address,UserID")] EmpProfile empProfile)
        {
            if (ModelState.IsValid)
            {                            
                db.Entry(empProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }
            return View(empProfile);
        }


        // GET: Profile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpProfile empProfile = db.EmpProfiles.Find(id);
            if (empProfile == null)
            {
                return HttpNotFound();
            }
            return View(empProfile);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpProfile empProfile = db.EmpProfiles.Find(id);
            db.EmpProfiles.Remove(empProfile);
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
