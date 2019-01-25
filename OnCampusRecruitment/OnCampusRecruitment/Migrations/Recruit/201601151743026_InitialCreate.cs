namespace OnCampusRecruitment.Migrations.Recruit
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyJobPost",
                c => new
                    {
                        CompanyJobPostID = c.Int(nullable: false, identity: true),
                        Industry = c.String(),
                        FunctionArea = c.Int(nullable: false),
                        TotalPosition = c.Int(nullable: false),
                        JobType = c.Int(nullable: false),
                        JobLocation = c.String(),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        MinimumEducation = c.Int(nullable: false),
                        DegreeTitle = c.Int(nullable: false),
                    CareerLevel = c.Int(nullable: false),
                        ApplyBy = c.DateTime(nullable: false),
                        JobPostingDate = c.DateTime(nullable: false),
                        JobDescription = c.String(nullable: false),
                        CompanyProfileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyJobPostID)
                .ForeignKey("dbo.CompanyProfile", t => t.CompanyProfileID, cascadeDelete: true)
                .Index(t => t.CompanyProfileID);
            
            CreateTable(
                "dbo.CompanyProfile",
                c => new
                    {
                        CompanyProfileID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false),
                        PersonName = c.String(nullable: false, maxLength: 50),
                        PersonContact = c.String(nullable: false),
                        Category = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        OfficeContact = c.String(nullable: false, maxLength: 13),
                        GroupOfCompany = c.String(maxLength: 50),
                        OwnerName = c.String(nullable: false, maxLength: 50),
                        HRHead = c.String(nullable: false, maxLength: 50),
                        CompanyWebsite = c.String(),
                        NoOfOffices = c.Int(nullable: false),
                        Fax = c.String(),
                        LogoName = c.String(),
                        Logo = c.Binary(),
                        OperatingSince = c.String(),
                        NoOfEmployees = c.Int(nullable: false),
                        OwnershipType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyProfileID);
            
            CreateTable(
                "dbo.DepartmentName",
                c => new
                    {
                        DepartmentNameID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentNameID);
            
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        EducationID = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(nullable: false),
                        SchoolYearPassing = c.Int(nullable: false),
                        SchoolDegree = c.Int(nullable: false),
                        CollegeName = c.String(nullable: false),
                        CollegeYearPassing = c.Int(nullable: false),
                        CollegeDegree = c.Int(nullable: false),
                        UniverstyName = c.String(nullable: false),
                        DepartmentName = c.String(nullable: false),
                        UniverstyYearPassing = c.Int(nullable: false),
                        GPA = c.Int(nullable: false),
                        EmpProfileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EducationID)
                .ForeignKey("dbo.EmpProfile", t => t.EmpProfileID, cascadeDelete: true)
                .Index(t => t.EmpProfileID);
            
            CreateTable(
                "dbo.EmpProfile",
                c => new
                    {
                        EmpProfileID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Gender = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        University = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        CNIC = c.String(maxLength: 13),
                        Contact = c.String(nullable: false),
                        Address = c.String(),
                        PhotoName = c.String(),
                        PhotoContent = c.Binary(),
                    })
                .PrimaryKey(t => t.EmpProfileID);
            
            CreateTable(
                "dbo.EmpCV",
                c => new
                    {
                        EmpCVID = c.Int(nullable: false, identity: true),
                        CvName = c.String(),
                        CvContent = c.Binary(),
                        EmpProfileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpCVID)
                .ForeignKey("dbo.EmpProfile", t => t.EmpProfileID, cascadeDelete: true)
                .Index(t => t.EmpProfileID);
            
            CreateTable(
                "dbo.EmpSkill",
                c => new
                    {
                        EmpSkillID = c.Int(nullable: false, identity: true),
                        SkillTitle = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Usage = c.Int(nullable: false),
                        EmpProfileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpSkillID)
                .ForeignKey("dbo.EmpProfile", t => t.EmpProfileID, cascadeDelete: true)
                .Index(t => t.EmpProfileID);
            
            CreateTable(
                "dbo.EmpWorkExperience",
                c => new
                    {
                        EmpWorkExperienceID = c.Int(nullable: false, identity: true),
                        ExperienceType = c.Int(nullable: false),
                        JobTitle = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Company = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Current = c.Boolean(nullable: false),
                        EmpProfileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpWorkExperienceID)
                .ForeignKey("dbo.EmpProfile", t => t.EmpProfileID, cascadeDelete: true)
                .Index(t => t.EmpProfileID);
            
            CreateTable(
                "dbo.SiteAdmin",
                c => new
                    {
                        SiteAdminID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserID = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SiteAdminID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpWorkExperience", "EmpProfileID", "dbo.EmpProfile");
            DropForeignKey("dbo.EmpSkill", "EmpProfileID", "dbo.EmpProfile");
            DropForeignKey("dbo.EmpCV", "EmpProfileID", "dbo.EmpProfile");
            DropForeignKey("dbo.Education", "EmpProfileID", "dbo.EmpProfile");
            DropForeignKey("dbo.CompanyJobPost", "CompanyProfileID", "dbo.CompanyProfile");
            DropIndex("dbo.EmpWorkExperience", new[] { "EmpProfileID" });
            DropIndex("dbo.EmpSkill", new[] { "EmpProfileID" });
            DropIndex("dbo.EmpCV", new[] { "EmpProfileID" });
            DropIndex("dbo.Education", new[] { "EmpProfileID" });
            DropIndex("dbo.CompanyJobPost", new[] { "CompanyProfileID" });
            DropTable("dbo.SiteAdmin");
            DropTable("dbo.EmpWorkExperience");
            DropTable("dbo.EmpSkill");
            DropTable("dbo.EmpCV");
            DropTable("dbo.EmpProfile");
            DropTable("dbo.Education");
            DropTable("dbo.DepartmentName");
            DropTable("dbo.CompanyProfile");
            DropTable("dbo.CompanyJobPost");
        }
    }
}
