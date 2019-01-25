using Microsoft.AspNet.Identity;
using OnCampusRecruitment.CustomFilters;
using OnCampusRecruitment.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnCampusRecruitment.Controllers
{
    [AuthLog(Roles = "company")]    
    public class CompanyDashboardController : Controller
    {
        public ActionResult Index()
        {
            RecruitDB db = new RecruitDB();
            string CurrentUser = User.Identity.GetUserId();
            int CurrentUserProfileID;
            if (db.CompanyProfiles.Where(r => r.UserID == CurrentUser).Any() == true)
            {
                CurrentUserProfileID = db.CompanyProfiles.Where(r => r.UserID == CurrentUser).First().CompanyProfileID;
            }
            else
            {
                return RedirectToAction("Create", "CompanyProfile");
            }
            ViewBag.A = db.CompanyProfiles.Where(r => r.UserID == CurrentUser).ToList();
            ViewBag.B = db.CompanyLogos.Where(r => r.CompanyProfileID == CurrentUserProfileID).ToList();
            ViewBag.C = db.CompanyJobPosts.Where(r => r.CompanyProfileID == CurrentUserProfileID).ToList();           
            ViewBag.CurrentUserBag = CurrentUserProfileID;
            return View();
        }
    }
}