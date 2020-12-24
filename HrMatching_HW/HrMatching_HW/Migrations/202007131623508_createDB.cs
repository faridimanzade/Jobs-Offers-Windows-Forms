namespace HrMatching_HW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CVs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Education = c.String(nullable: false),
                        Job = c.String(nullable: false),
                        Experience = c.String(nullable: false),
                        City = c.String(nullable: false),
                        MinSalary = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Vacancies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        VacancyName = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Education = c.String(nullable: false),
                        Experience = c.String(nullable: false),
                        Job = c.String(nullable: false),
                        JobDescription = c.String(nullable: false),
                        City = c.String(nullable: false),
                        SalaryOffer = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VacancyCVs",
                c => new
                    {
                        Vacancy_id = c.Int(nullable: false),
                        CV_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vacancy_id, t.CV_id })
                .ForeignKey("dbo.Vacancies", t => t.Vacancy_id, cascadeDelete: true)
                .ForeignKey("dbo.CVs", t => t.CV_id, cascadeDelete: true)
                .Index(t => t.Vacancy_id)
                .Index(t => t.CV_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CVs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Vacancies", "UserId", "dbo.Users");
            DropForeignKey("dbo.VacancyCVs", "CV_id", "dbo.CVs");
            DropForeignKey("dbo.VacancyCVs", "Vacancy_id", "dbo.Vacancies");
            DropIndex("dbo.VacancyCVs", new[] { "CV_id" });
            DropIndex("dbo.VacancyCVs", new[] { "Vacancy_id" });
            DropIndex("dbo.Vacancies", new[] { "UserId" });
            DropIndex("dbo.CVs", new[] { "UserId" });
            DropTable("dbo.VacancyCVs");
            DropTable("dbo.Vacancies");
            DropTable("dbo.Users");
            DropTable("dbo.CVs");
        }
    }
}
