using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnCampusRecruitment.Models
{
    public class EmpCV
    {
        public int EmpCVID { get; set; }

        [DisplayName("Resume Title")]
        public string CvName { get; set; }

        //public string ContentType { get; set; }
               
        public byte[] CvContent { get; set; }

        public int EmpProfileID { get; set; }

        public virtual EmpProfile EmpProfile { get; set; }
    }
}