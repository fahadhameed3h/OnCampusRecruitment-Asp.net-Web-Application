using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnCampusRecruitment.Models
{
    

    public class EmpWorkExperience
    {
        public int EmpWorkExperienceID { get; set; }


        [Required]
        [DisplayName("Experience Type")]
        public ExperienceType? ExperienceType { get; set; }

        [Required]
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [Required]
        public FunctionArea? Category { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        [DisplayName("Job Starting Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("Job Ending Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required]
        public bool Current { get; set; }
        
        public int EmpProfileID { get; set; }

        public virtual EmpProfile EmpProfile { get; set; }
    }
}










