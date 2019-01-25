using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OnCampusRecruitment.DAL;
using OnCampusRecruitment.Models;
using Microsoft.AspNet.Identity;
using OnCampusRecruitment.CustomFilters;

namespace OnCampusRecruitment.Controllers
{

    public class JobController : Controller
    {
        private RecruitDB db = new RecruitDB();

        [AuthLog(Roles = "company")]
        public ActionResult Index()
        {            
            string CurrentUser = User.Identity.GetUserId();
            
            if (db.CompanyProfiles.Where(r => r.UserID == CurrentUser).FirstOrDefault() == null)
            {
                return RedirectToAction("Create", "CompanyProfile");
            }
            
            else if (db.CompanyProfiles.Where(r=> r.UserID == CurrentUser).First().Verified  == true)
            {
                int compProfileID = db.CompanyProfiles.Where(r => r.UserID == CurrentUser).First().CompanyProfileID;
                var jobOBJ = db.CompanyJobPosts.Where(r => r.CompanyProfileID == compProfileID);
                return View(jobOBJ.ToList());
            }
            else
            {
                return RedirectToAction("PlacementOffice");
            }
        }

        [AuthLog(Roles = "company")]
        public ActionResult PlacementOffice()
        {
            ViewBag.Message = "Contact GCU Lahore Placement Office to confirm the account.";
            return View();
        }

        public ActionResult Details(int? id)
        {           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobPost companyJobPost = db.CompanyJobPosts.Find(id);
            if (companyJobPost == null)
            {
                return HttpNotFound();
            }
            return View(companyJobPost);
        }

        [AuthLog(Roles = "company")]
        public ActionResult Create()
        {
            string CurrentUser = User.Identity.GetUserId();
            if (db.CompanyProfiles.Where(r => r.UserID == CurrentUser).Any() == false)
            {
                return RedirectToAction("Create", "CompanyProfile");
            }
            if (db.CompanyProfiles.Where(r => r.UserID == CurrentUser).First().Verified == true)
            {
                int CurrentUserProfileID = db.CompanyProfiles.Where(r => r.UserID == CurrentUser).First().CompanyProfileID;
                ViewBag.CompanyProfileID = CurrentUserProfileID;
                return View();
            }
            return RedirectToAction("PlacementOffice");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyJobPostID,Industry,FunctionArea,TotalPosition,JobType,JobLocation,Gender,Age,MinimumEducation,DegreeTitle,CareerLevel,ApplyBy,JobPostingDate,JobDescription,CompanyProfileID")] CompanyJobPost companyJobPost)
        {
            if (ModelState.IsValid)
            {                
                db.CompanyJobPosts.Add(companyJobPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            string CurrentUser = User.Identity.GetUserId();
            int CurrentUserProfileID = db.CompanyProfiles.Where(r => r.UserID == CurrentUser).First().CompanyProfileID;
            ViewBag.CompanyProfileID = CurrentUserProfileID;
            
            // ViewBag.CompanyProfileID = new SelectList(db.CompanyProfiles, "CompanyProfileID", "UserID", companyJobPost.CompanyProfileID);
            return View(companyJobPost);
        }

        // GET: Job/Edit/5
        [AuthLog(Roles = "company")]
        public ActionResult Edit(int? id)
        {
            string CurrentUser = User.Identity.GetUserId();            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (db.CompanyProfiles.Where(r => r.UserID == CurrentUser).First().Verified == false)
            {
                return RedirectToAction("PlacementOffice");
            }
            CompanyJobPost companyJobPost = db.CompanyJobPosts.Find(id);
            if (companyJobPost == null)
            {
                return HttpNotFound();
            }           
            ViewBag.CompanyProfileID = new SelectList(db.CompanyProfiles, "CompanyProfileID", "UserID", companyJobPost.CompanyProfileID);
            return View(companyJobPost);
        }

        // POST: Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthLog(Roles = "company")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyJobPostID,Industry,FunctionArea,TotalPosition,JobType,JobLocation,Gender,Age,MinimumEducation,DegreeTitle,CareerLevel,ApplyBy,JobPostingDate,JobDescription,CompanyProfileID")] CompanyJobPost companyJobPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyJobPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyProfileID = new SelectList(db.CompanyProfiles, "CompanyProfileID", "UserID", companyJobPost.CompanyProfileID);
            return View(companyJobPost);
        }

        // GET: Job/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobPost companyJobPost = db.CompanyJobPosts.Find(id);
            if (companyJobPost == null)
            {
                return HttpNotFound();
            }
            return View(companyJobPost);
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyJobPost companyJobPost = db.CompanyJobPosts.Find(id);
            db.CompanyJobPosts.Remove(companyJobPost);
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
