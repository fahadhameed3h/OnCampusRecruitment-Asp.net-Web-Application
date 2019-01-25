using OnCampusRecruitment.CustomFilters;
using OnCampusRecruitment.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnCampusRecruitment.Models;
using System.Data.Entity;

namespace OnCampusRecruitment.Controllers
{
    [AuthLog(Roles = "admin")]
    public class AdminController : Controller
    {
        private RecruitDB db = new RecruitDB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Company()
        {            
            ViewBag.A = db.CompanyProfiles;           
            return View();
        }

        public ActionResult Student()
        {
            RecruitDB db = new RecruitDB();
            List<EmpProfile> employeeprofile = db.EmpProfiles.ToList();
            return View(employeeprofile);
        }
    }
}