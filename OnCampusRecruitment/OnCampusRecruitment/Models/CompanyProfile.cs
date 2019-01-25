using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnCampusRecruitment.Models
{   
    public class CompanyProfile
    {
        public int CompanyProfileID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [DisplayName("Employee Name")]
        public string PersonName { get; set; }

        [Phone]
        [DisplayName("Employee Contact Number")]
        [Required(ErrorMessage = "Contact Number Required")]
        public string PersonContact { get; set; }
       
        [Required]
        [DisplayName("Industry")]
        public Industry? Category { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public City? City { get; set; }

        [Required]
        [Phone]
        [DisplayName("Contact Number")]
        [StringLength(13, MinimumLength = 1, ErrorMessage = "CNIC Number can only be 13 Digits long.")]
        public string OfficeContact { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Company Name cannot be longer than 50 characters.")]
        [DisplayName("Group Of Company")]
        public string GroupOfCompany { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "CEO/Head Name cannot be longer than 50 characters.")]
        [DisplayName("CEO/Head Name")]
        public string OwnerName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "CEO/Head Name cannot be longer than 50 characters.")]
        [DisplayName("Head HR Department")]
        public string HRHead { get; set; }

        [DisplayName("Company Website")]
        public string CompanyWebsite { get; set; }

        [DisplayName("No Of Offices")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int NoOfOffices { get; set; }

        [DisplayName("Fax")]
        public string Fax { get; set; }

        [DisplayName("Operating Since")]
        public string OperatingSince { get; set; }

        [DisplayName("No Of Employees")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int NoOfEmployees { get; set; }

        [DisplayName("Ownership Type")]
        public OwnershipType OwnershipType { get; set; }

        //For Admin User to confirm the company is authorised
        public bool Verified { get; set; }

        public virtual ICollection<CompanyJobPost> CompanyJobPosts { get; set; }
        public virtual CompanyLogo CompanyLogo { get; set; }
    }
}