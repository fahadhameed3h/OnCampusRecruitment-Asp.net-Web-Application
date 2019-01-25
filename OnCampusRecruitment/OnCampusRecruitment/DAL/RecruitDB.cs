using OnCampusRecruitment.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OnCampusRecruitment.DAL
{
    public class RecruitDB : DbContext
    {
        public DbSet<EmpProfile> EmpProfiles { get; set; }        
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<EmpSkill> EmpSkills { get; set; }
        public DbSet<EmpWorkExperience> EmpWorkExperiences { get; set; }
        public DbSet<EmpCV> EmpCVs { get; set; }
        public DbSet<ProfilePhoto> ProfilePhotos { get; set; }

        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<CompanyJobPost> CompanyJobPosts { get; set; }
        public DbSet<CompanyLogo> CompanyLogos { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        //public DbSet<SiteAdmin> SiteAdmins { get; set; }      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // This method modelBuilder.Conventions.Remove statement in the OnModelCreating method prevents table names from being pluralized. If you didn't do this, the generated tables would be named Students, Courses, and Enrollments. Instead, the table names will be Student, Course, and Enrollment.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }        
    }
}

