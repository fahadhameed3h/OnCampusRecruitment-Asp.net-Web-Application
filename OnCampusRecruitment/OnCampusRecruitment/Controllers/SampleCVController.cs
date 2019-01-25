using Microsoft.AspNet.Identity;
using OnCampusRecruitment.CustomFilters;
using OnCampusRecruitment.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnCampusRecruitment.Controllers
{
    [AuthLog(Roles = "student")]
    public class SampleCVController : Controller
    {
        public ActionResult Index()
        {
            RecruitDB db = new RecruitDB();
            string CurrentUser = User.Identity.GetUserId();
            int CurrentUserProfileID;
            if (db.EmpProfiles.Where(r => r.UserID == CurrentUser).Any() == true)
            {
                CurrentUserProfileID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;
            }
            else
            {
                return RedirectToAction("Create", "Profile");
            }
            ViewBag.A = db.EmpProfiles.Where(r => r.UserID == CurrentUser).ToList();
            ViewBag.B = db.ProfilePhotos.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();


            string Description = db.Qualifications.Where(r => r.EmpProfileID == CurrentUserProfileID).First().Description;
            ViewBag.StudentDescription = Description;

            string Nationality = db.EmpProfiles.Where(r => r.EmpProfileID == CurrentUserProfileID).First().Nationality;
            ViewBag.Nationality = Nationality;
            string DOB = db.EmpProfiles.Where(r => r.EmpProfileID == CurrentUserProfileID).First().DOB.ToShortDateString();
            ViewBag.DOB = DOB;

            string CNIC = db.EmpProfiles.Where(r => r.EmpProfileID == CurrentUserProfileID).First().CNIC;
            ViewBag.CNIC = CNIC;

            ViewBag.Qualification = db.Qualifications.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();

            ViewBag.Skill = db.EmpSkills.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();
            ViewBag.Experience = db.EmpWorkExperiences.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();
            ViewBag.F = db.EmpCVs.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();
            ViewBag.CurrentUserBag = CurrentUserProfileID;           
            return new Rotativa.ViewAsPdf("Index");
        }
        public ActionResult CVTemplate()
        {
            RecruitDB db = new RecruitDB();
            string CurrentUser = User.Identity.GetUserId();
            int CurrentUserProfileID;
            if (db.EmpProfiles.Where(r => r.UserID == CurrentUser).Any() == true)
            {
                CurrentUserProfileID = db.EmpProfiles.Where(r => r.UserID == CurrentUser).First().EmpProfileID;
            }
            else
            {
                return RedirectToAction("Create", "Profile");
            }
            ViewBag.A = db.EmpProfiles.Where(r => r.UserID == CurrentUser).ToList();
            ViewBag.B = db.ProfilePhotos.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();


            string Description = db.Qualifications.Where(r => r.EmpProfileID == CurrentUserProfileID).First().Description;
            ViewBag.StudentDescription = Description;

            string Nationality = db.EmpProfiles.Where(r => r.EmpProfileID == CurrentUserProfileID).First().Nationality;
            ViewBag.Nationality = Nationality;
            string DOB = db.EmpProfiles.Where(r => r.EmpProfileID == CurrentUserProfileID).First().DOB.ToShortDateString();
            ViewBag.DOB = DOB;
            string CNIC = db.EmpProfiles.Where(r => r.EmpProfileID == CurrentUserProfileID).First().CNIC;
            ViewBag.CNIC = CNIC;

            ViewBag.Qualification = db.Qualifications.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();

            ViewBag.Skill = db.EmpSkills.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();
            ViewBag.Experience = db.EmpWorkExperiences.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();
            ViewBag.F = db.EmpCVs.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();
            ViewBag.CurrentUserBag = CurrentUserProfileID;
            return new Rotativa.ViewAsPdf("CVTemplate");
        }
    }
}