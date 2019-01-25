using OnCampusRecruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnCampusRecruitment.ViewModels
{
    public class StudentDisplay
    {
        public IEnumerable<EmpProfile> EmpProfiles { get; set; }
        public IEnumerable<EmpSkill> EmpSkills { get; set; }
        public IEnumerable<EmpWorkExperience> EmpWorkExperiences { get; set; }
        public IEnumerable<ProfilePhoto> ProfilePhotos { get; set; }
        public IEnumerable<Qualification> Qualifications { get; set; }       
    }
}

