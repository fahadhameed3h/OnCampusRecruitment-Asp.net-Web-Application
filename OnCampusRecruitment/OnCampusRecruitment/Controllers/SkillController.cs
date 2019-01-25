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
    public class SkillController : Controller
    {
        private RecruitDB db = new RecruitDB();

        // GET: Skill
        public ActionResult Index()
        {            
            string CurrentUser = User.Identity.GetUserId();
            
            if (db.EmpProfiles.Where(r => r.UserID == CurrentUser).FirstOrDefault() == null)
            {
                return RedirectToAction("Create", "Profile");                
            }
            else {
                int empProfileID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;
                var empSkills = db.EmpSkills.Where(r => r.EmpProfileID == empProfileID);
                return View(empSkills.ToList());
            }
        }

        // GET: Skill/Create
        public ActionResult Create()
        {
            string CurrentUser = User.Identity.GetUserId();
            int CurrentUserProfileID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;            
            ViewBag.EmpProfileID = CurrentUserProfileID;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpSkillID,SkillTitle,Category,Usage,EmpProfileID")] EmpSkill empSkill)
        {
            if (ModelState.IsValid)
            {
                db.EmpSkills.Add(empSkill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "FirstName", empSkill.EmpProfileID);
            return View(empSkill);
        }

        // GET: Skill/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpSkill empSkill = db.EmpSkills.Find(id);
            if (empSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "FirstName", empSkill.EmpProfileID);
            return View(empSkill);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpSkillID,SkillTitle,Category,Usage,EmpProfileID")] EmpSkill empSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "FirstName", empSkill.EmpProfileID);
            return View(empSkill);
        }

        // GET: Skill/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpSkill empSkill = db.EmpSkills.Find(id);
            if (empSkill == null)
            {
                return HttpNotFound();
            }
            return View(empSkill);
        }

        // POST: Skill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpSkill empSkill = db.EmpSkills.Find(id);
            db.EmpSkills.Remove(empSkill);
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
