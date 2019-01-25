namespace OnCampusRecruitment.Migrations.Recruit
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyJobPost", "JobDescription", c => c.String(nullable: false, unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyJobPost", "JobDescription", c => c.String(nullable: false));
        }
    }
}
