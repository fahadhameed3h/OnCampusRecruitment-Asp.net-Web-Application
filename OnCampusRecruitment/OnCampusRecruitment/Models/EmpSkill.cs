using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnCampusRecruitment.Models
{
    

    public class EmpSkill
    {
        public int EmpSkillID { get; set; }        

        [Required]
        [DisplayName("Skill Name")]
        public string SkillTitle { get; set; }

        [Required]
        [DisplayName("Category")]
        public FunctionArea? Category { get; set; }

        [Required]
        [DisplayName("Usage")]
        public Usage? Usage { get; set; }        

        public int EmpProfileID { get; set; }

        public virtual EmpProfile EmpProfile { get; set; }
    }
}