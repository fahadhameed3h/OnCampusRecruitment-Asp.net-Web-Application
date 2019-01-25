using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using OnCampusRecruitment.CustomFilters;
using OnCampusRecruitment.DAL;

namespace OnCampusRecruitment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {                        
            return View();
        }
               
        public ActionResult Jobs(string sortOrder, string searchString)
        {
            RecruitDB db = new RecruitDB();
          
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var jobsVar = from s in db.CompanyJobPosts
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobsVar = jobsVar.Where(s => s.DegreeTitle.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    jobsVar = jobsVar.OrderByDescending(s => s.CompanyProfile.GroupOfCompany);
                    break;
                case "Date":
                    jobsVar = jobsVar.OrderBy(s => s.JobPostingDate);
                    break;
                case "date_desc":
                    jobsVar = jobsVar.OrderByDescending(s => s.JobPostingDate);
                    break;
                default:
                    jobsVar = jobsVar.OrderBy(s => s.CompanyProfile.GroupOfCompany);
                    break;
            }
            return View(jobsVar.ToList());
        }


        public ActionResult Companies(string sortOrder, string searchString)
        {
            RecruitDB db = new RecruitDB();

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
           
            var Company = from s in db.CompanyProfiles
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Company = Company.Where(s => s.GroupOfCompany.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Company = Company.OrderByDescending(s => s.GroupOfCompany);
                    break;               
                default:
                    Company = Company.OrderBy(s => s.GroupOfCompany);
                    break;
            }
            return View(Company.ToList());
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}