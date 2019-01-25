using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnCampusRecruitment.Models
{    
    public class EmpProfile
    {
        public int EmpProfileID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [DisplayName("First Name")]        
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        [Required]
        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]        
        public DateTime DOB { get; set; }

        [Required]
        public University? University { get; set; }

        [Required]
        public City? City { get; set; }

        [Required]
        public string Nationality { get; set; }

        //[Required]
        [StringLength(13, MinimumLength = 1, ErrorMessage = "CNIC Number can only be 13 Digits long.")]
        public string CNIC { get; set; }

        [Phone]
        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "Contact Number Required")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered Mobile Phone format is not valid.")]
        public string Contact { get; set; }
       
        [DisplayName("Residential Address")]
        public string Address { get; set; }     

        public virtual ICollection<EmpSkill> EmpSkills { get; set; }        
        public virtual ICollection<EmpWorkExperience> EmpWorkExperiences { get; set; }
        public virtual ICollection<EmpCV> EmpCVs { get; set; }        
        public virtual Qualification Qualification { get; set; }
        public virtual ProfilePhoto ProfilePhoto { get; set; }
    }
}