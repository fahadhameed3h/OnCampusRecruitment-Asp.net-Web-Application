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
   
    public class CompanyProfileController : Controller
    {
        private RecruitDB db = new RecruitDB();
        
        [AuthLog(Roles = "admin")]
        public ActionResult Index()
        {
            string abc = User.Identity.GetUserId();
            return View(db.CompanyProfiles.Where(r => r.UserID == abc).ToList());            
        }

        [AuthLog(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfile companyProfile = db.CompanyProfiles.Find(id);
            if (companyProfile == null)
            {
                return HttpNotFound();
            }
            return View(companyProfile);
        }

        [AuthLog(Roles = "company")]
        public ActionResult Create()
        {
            string abc = User.Identity.GetUserId();
            if (db.CompanyProfiles.Where(r => r.UserID == abc).Any() == true)
            {
                return RedirectToAction("Edit", "CompanyProfile");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthLog(Roles = "company")]
        public ActionResult Create([Bind(Include = "CompanyProfileID,UserID,PersonName,PersonContact,Category,Address,City,OfficeContact,GroupOfCompany,OwnerName,HRHead,CompanyWebsite,NoOfOffices,Fax,OperatingSince,NoOfEmployees,OwnershipType")] CompanyProfile companyProfile)
        {        
            if (ModelState.IsValid)
            {               
                db.CompanyProfiles.Add(companyProfile);
                db.SaveChanges();
                return RedirectToAction("Index", "CompanyDashboard");
            }
            return View(companyProfile);         
        }

        [Authorize(Roles ="company")]
        public ActionResult Edit()
        {
            string abc = User.Identity.GetUserId();
            int id = db.CompanyProfiles.Where(r => r.UserID == abc).First().CompanyProfileID;
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompanyProfile comProfile = db.CompanyProfiles.Find(id);
            if (comProfile == null)
            {
                return HttpNotFound();
            }
            return View(comProfile);           
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "company")]
        public ActionResult Edit([Bind(Include = "CompanyProfileID,UserID,PersonName,PersonContact,Category,Address,City,OfficeContact,GroupOfCompany,OwnerName,HRHead,CompanyWebsite,NoOfOffices,Fax,LogoName,Logo,OperatingSince,NoOfEmployees,OwnershipType,verified")] CompanyProfile companyProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "CompanyDashboard");
            }
            return View(companyProfile);           
        }


        [Authorize(Roles = "admin")]
        public ActionResult AdminEdit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfile compProfile = db.CompanyProfiles.Find(id);
            if (compProfile == null)
            {
                return HttpNotFound();
            }            
            return View(compProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult AdminEdit([Bind(Include  = "CompanyProfileID,UserID,PersonName,PersonContact,Category,Address,City,OfficeContact,GroupOfCompany,OwnerName,HRHead,CompanyWebsite,NoOfOffices,Fax,LogoName,Logo,OperatingSince,NoOfEmployees,OwnershipType,verified")] CompanyProfile companyProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Company", "Admin");
            }
            return View(companyProfile);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfile companyProfile = db.CompanyProfiles.Find(id);
            if (companyProfile == null)
            {
                return HttpNotFound();
            }
            return View(companyProfile);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyProfile companyProfile = db.CompanyProfiles.Find(id);
            db.CompanyProfiles.Remove(companyProfile);
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
