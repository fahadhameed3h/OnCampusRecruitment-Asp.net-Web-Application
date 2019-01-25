using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnCampusRecruitment.Models
{
    public class JobApplication
    {
        [Key]
        [Column(Order = 0)]
        public int CompanyJobPostID { get; set; }              
        
        [Key]
        [Column(Order = 1)]
        public int EmpProfileID { get; set; }        

        public virtual CompanyJobPost CompanyJobPost { get; set; }
        public virtual EmpProfile EmpProfile { get; set; }
    }
}