using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnCampusRecruitment.Models
{
    public class ProfilePhoto
    {
        [Key]
        [ForeignKey("EmpProfile")]
        public int EmpProfileID { get; set; }

        // For Profile Photo
        public string PhotoName { get; set; }
        public byte[] PhotoContent { get; set; }

        public virtual EmpProfile EmpProfile { get; set; }
    }
}