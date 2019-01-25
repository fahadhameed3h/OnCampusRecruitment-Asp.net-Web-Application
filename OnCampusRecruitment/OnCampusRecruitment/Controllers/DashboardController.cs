using Microsoft.AspNet.Identity;
using OnCampusRecruitment.CustomFilters;
using OnCampusRecruitment.DAL;
using System.Linq;
using System.Web.Mvc;

namespace OnCampusRecruitment.Controllers
{
    [AuthLog(Roles = "student")]
    public class DashboardController : Controller
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
            ViewBag.C = db.Qualifications.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();
            ViewBag.D = db.EmpSkills.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();
            ViewBag.E = db.EmpWorkExperiences.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();
            ViewBag.F = db.EmpCVs.Where(r => r.EmpProfileID == CurrentUserProfileID).ToList();            
            ViewBag.CurrentUserBag = CurrentUserProfileID;
            return View();
        }
    }
}