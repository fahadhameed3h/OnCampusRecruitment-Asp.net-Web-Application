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
    public class CVController : Controller
    {
        private RecruitDB db = new RecruitDB();

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
                var empCV = db.EmpCVs.Where(r => r.EmpProfileID == empProfileID);
                return View(empCV.ToList());
            }           
        }

        public ActionResult Create()
        {
            string CurrentUser = User.Identity.GetUserId();
            int emp_ID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;
            int countCV = db.EmpCVs.Where(r => r.EmpProfileID == emp_ID).Count();

            if (db.EmpProfiles.Where(r => r.UserID == CurrentUser).Any() == false)
            {
                return RedirectToAction("Create", "Profile");
            }            
            else if (countCV == 0 || countCV < 2)
            {
                int empProfileID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;
                var empCV = db.EmpCVs.Where(r => r.EmpProfileID == empProfileID);
                ViewBag.EmpProfileID = empProfileID;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "CV");
            }
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpCVID,CvName,CvContent,EmpProfileID")] EmpCV empCV, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    if (empCV.CvName == null)
                    {
                        empCV.CvName = System.IO.Path.GetFileName(upload.FileName);
                        byte[] data = new byte[upload.ContentLength];
                        upload.InputStream.Read(data, 0, upload.ContentLength);
                        empCV.CvContent = data;
                    }
                    else
                    {
                        byte[] data = new byte[upload.ContentLength];
                        upload.InputStream.Read(data, 0, upload.ContentLength);
                        empCV.CvContent = data;
                    }
                }

                db.EmpCVs.Add(empCV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "UserID", empCV.EmpProfileID);
            return View(empCV);
        }

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EmpCV empCV = db.EmpCVs.Find(id);
        //    if (empCV == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "UserID", empCV.EmpProfileID);
        //    return View(empCV);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "EmpCVID,CvName,CvContent,EmpProfileID")] EmpCV empCV, HttpPostedFileBase upload)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (upload != null && upload.ContentLength > 0)
        //        {
        //            empCV.CvName = System.IO.Path.GetFileName(upload.FileName);
        //            byte[] data = new byte[upload.ContentLength];
        //            upload.InputStream.Read(data, 0, upload.ContentLength);

        //            empCV.CvContent = data;
        //        }

        //        db.Entry(empCV).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "UserID", empCV.EmpProfileID);
        //    return View(empCV);
        //}

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpCV empCV = db.EmpCVs.Find(id);
            if (empCV == null)
            {
                return HttpNotFound();
            }
            return View(empCV);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpCV empCV = db.EmpCVs.Find(id);
            db.EmpCVs.Remove(empCV);
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
