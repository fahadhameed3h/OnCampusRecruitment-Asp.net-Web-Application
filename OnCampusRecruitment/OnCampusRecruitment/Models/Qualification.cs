using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnCampusRecruitment.Models
{
    public class Qualification
    {
        [Key]
        [ForeignKey("EmpProfile")]
        public int EmpProfileID { get; set; }

        [Required]
        [DisplayName("School Name")]
        public string SchoolName { get; set; }
        [Required]
        [DisplayName("Passing Out Year")]
        public int SchoolYearPassing { get; set; }
        [Required]
        [DisplayName("SSC")]
        public SchoolDegree? SchoolDegree { get; set; }

        [Required]
        [DisplayName("College Name")]
        public string CollegeName { get; set; }
        [Required]
        [DisplayName("Passing Out Year")]
        public int CollegeYearPassing { get; set; }
        [Required]
        [DisplayName("Intermediate")]
        public CollegeDegree? CollegeDegree { get; set; }

        [Required]
        [DisplayName("University Name")]
        public string UniverstyName { get; set; }
        [Required]
        [DisplayName("Degree Title")]
        public DegreeTitle? DepartmentName { get; set; }
        [Required]
        [DisplayName("Passing Out Year")]
        public int UniverstyYearPassing { get; set; }
        [Required]
        [DisplayName("GPA")]
        [Range(2, 4, ErrorMessage = "GPA should be between 2 and 4.")]
        public decimal GPA { get; set; }

        [Required]
        [DisplayName("Personal Profile")]        
        public string Description { get; set; }

        public virtual EmpProfile EmpProfile { get; set; }
    }
}
