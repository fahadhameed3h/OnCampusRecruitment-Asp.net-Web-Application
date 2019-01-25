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
    [AuthLog(Roles = "company")]
    public class LogoController : Controller
    {
        private RecruitDB db = new RecruitDB();

        //public ActionResult Index()
        //{
        //    var companyLogos = db.CompanyLogos.Include(c => c.CompanyProfile);
        //    return View(companyLogos.ToList());
        //}

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CompanyLogo companyLogo = db.CompanyLogos.Find(id);
        //    if (companyLogo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(companyLogo);
        //}

        public ActionResult Create()
        {
            string CurrentUser = User.Identity.GetUserId();
            if (db.CompanyProfiles.Where(r => r.UserID == CurrentUser).Any() == false)
            {
                return RedirectToAction("Create", "CompanyProfile");
            }
            int CurrentUserProfileID = db.CompanyProfiles.Where(r => r.UserID == CurrentUser).First().CompanyProfileID;
            ViewBag.CompanyProfileID = CurrentUserProfileID;
            return View();                    
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyProfileID,PhotoName,PhotoContent")] CompanyLogo companyLogo, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    companyLogo.PhotoName = System.IO.Path.GetFileName(upload.FileName);
                    byte[] data = new byte[upload.ContentLength];
                    upload.InputStream.Read(data, 0, upload.ContentLength);

                    companyLogo.PhotoContent = data;
                }
                db.CompanyLogos.Add(companyLogo);
                db.SaveChanges();
                return RedirectToAction("Index", "CompanyDashboard");                
            }
            return View(companyLogo);
        }
      
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyLogo companyLogo = db.CompanyLogos.Find(id);
            if (companyLogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyProfileID = new SelectList(db.CompanyProfiles, "CompanyProfileID", "UserID", companyLogo.CompanyProfileID);
            return View(companyLogo);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyProfileID,PhotoName,PhotoContent")] CompanyLogo companyLogo, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    companyLogo.PhotoName = System.IO.Path.GetFileName(upload.FileName);
                    byte[] data = new byte[upload.ContentLength];
                    upload.InputStream.Read(data, 0, upload.ContentLength);

                    companyLogo.PhotoContent = data;
                }
                db.Entry(companyLogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "CompanyDashboard");
            }
            ViewBag.CompanyProfileID = new SelectList(db.CompanyProfiles, "CompanyProfileID", "UserID", companyLogo.CompanyProfileID);
            return View(companyLogo);
        }

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CompanyLogo companyLogo = db.CompanyLogos.Find(id);
        //    if (companyLogo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(companyLogo);
        //}
   
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CompanyLogo companyLogo = db.CompanyLogos.Find(id);
        //    db.CompanyLogos.Remove(companyLogo);
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
