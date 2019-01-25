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
    [AuthLog(Roles = "student")]
    public class ProfilePhotoController : Controller
    {
        private RecruitDB db = new RecruitDB();
        
        //public ActionResult Index()
        //{
        //    var profilePhotos = db.ProfilePhotos.Include(p => p.EmpProfile);
        //    return View(profilePhotos.ToList());
        //}
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProfilePhoto profilePhoto = db.ProfilePhotos.Find(id);
        //    if (profilePhoto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(profilePhoto);
        //}

        public ActionResult Create()
        {
            string CurrentUser = User.Identity.GetUserId();
            if (db.EmpProfiles.Where(r => r.UserID == CurrentUser).Any() == false)
            {
                return RedirectToAction("Create", "Profile");
            }                       
            int CurrentUserProfileID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;
            ViewBag.EmpProfileID = CurrentUserProfileID;
            return View();           
        }
             
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpProfileID,PhotoName,PhotoContent")] ProfilePhoto profilePhoto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    profilePhoto.PhotoName = System.IO.Path.GetFileName(upload.FileName);
                    byte[] data = new byte[upload.ContentLength];
                    upload.InputStream.Read(data, 0, upload.ContentLength);

                    profilePhoto.PhotoContent = data;
                }
                db.ProfilePhotos.Add(profilePhoto);
                db.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }
            return PartialView(profilePhoto);
        }

        public ActionResult Edit()
        {
            string abc = User.Identity.GetUserId();
            int? id = db.EmpProfiles.Where(r => r.UserID == abc).First().EmpProfileID;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfilePhoto profilePhoto = db.ProfilePhotos.Find(id);
            if (profilePhoto == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "UserID", profilePhoto.EmpProfileID);
            return View(profilePhoto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpProfileID,PhotoName,PhotoContent")] ProfilePhoto profilePhoto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    profilePhoto.PhotoName = System.IO.Path.GetFileName(upload.FileName);
                    byte[] data = new byte[upload.ContentLength];
                    upload.InputStream.Read(data, 0, upload.ContentLength);

                    profilePhoto.PhotoContent = data;
                }
                db.Entry(profilePhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }
          
            ViewBag.EmpProfileID = new SelectList(db.EmpProfiles, "EmpProfileID", "UserID", profilePhoto.EmpProfileID);
            return View(profilePhoto);
        }
        
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProfilePhoto profilePhoto = db.ProfilePhotos.Find(id);
        //    if (profilePhoto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(profilePhoto);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ProfilePhoto profilePhoto = db.ProfilePhotos.Find(id);
        //    db.ProfilePhotos.Remove(profilePhoto);
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
