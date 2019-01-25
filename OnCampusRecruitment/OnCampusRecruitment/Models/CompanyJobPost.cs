using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnCampusRecruitment.Models
{
    public class CompanyJobPost
    {
        public int CompanyJobPostID { get; set; }

        public Industry? Industry { get; set; }

        [Required]
        [DisplayName("Functional Area")]
        public FunctionArea? FunctionArea { get; set; }

        [Required]
        [DisplayName("Total Position")]
        [Range(1,20, ErrorMessage = "Positions should be between 1 and 20.")]
        public int TotalPosition  { get; set; }

        [Required]
        [DisplayName("Job Type")]
        public JobType? JobType { get; set; }

        [DisplayName("Job Location")]
        public City? JobLocation { get; set; }

        [Required]
        public GenderSelect? Gender { get; set; }

        [Required]
        public Age Age { get; set; }

        [Required]
        [DisplayName("Minimum Education")]
        public MinimumEducation? MinimumEducation { get; set; }

        [Required]
        [DisplayName("Degree Title")]
        public DegreeTitle? DegreeTitle { get; set; }

        [Required]
        [DisplayName("Career Level")]
        public CareerLevel? CareerLevel { get; set; }

        [Required]
        [DisplayName("Apply By")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ApplyBy { get; set; }

        [Required]
        [DisplayName("Job Posting Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JobPostingDate { get; set; }

        [Required]        
        [DisplayName("Job Description")]
        [UIHint("tinymce_jquery_full"),AllowHtml]
        public string JobDescription { get; set; }

        public int CompanyProfileID { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }
    }
}