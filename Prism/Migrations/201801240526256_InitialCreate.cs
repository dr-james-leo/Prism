namespace Prism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        ConsultantId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        GradeId = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultantId)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.GradeId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.SkillId);
            
            CreateTable(
                "dbo.GradeScoringMatrixCells",
                c => new
                    {
                        GradeScoringMatrixCellId = c.Int(nullable: false, identity: true),
                        SubstituteScore = c.Int(nullable: false),
                        DesiredGrade_GradeId = c.Int(),
                        SubstituteGrade_GradeId = c.Int(),
                    })
                .PrimaryKey(t => t.GradeScoringMatrixCellId)
                .ForeignKey("dbo.Grades", t => t.DesiredGrade_GradeId)
                .ForeignKey("dbo.Grades", t => t.SubstituteGrade_GradeId)
                .Index(t => t.DesiredGrade_GradeId)
                .Index(t => t.SubstituteGrade_GradeId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 3),
                        Name = c.String(nullable: false, maxLength: 100),
                        ClientId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SkillScoringMatrixCells",
                c => new
                    {
                        SkillScoringMatrixCellId = c.Int(nullable: false, identity: true),
                        SubstituteScore = c.Int(nullable: false),
                        DesiredSkill_SkillId = c.Int(),
                        SubstituteSkill_SkillId = c.Int(),
                    })
                .PrimaryKey(t => t.SkillScoringMatrixCellId)
                .ForeignKey("dbo.Skills", t => t.DesiredSkill_SkillId)
                .ForeignKey("dbo.Skills", t => t.SubstituteSkill_SkillId)
                .Index(t => t.DesiredSkill_SkillId)
                .Index(t => t.SubstituteSkill_SkillId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ConsultantSkills",
                c => new
                    {
                        ConsultantId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ConsultantId, t.SkillId })
                .ForeignKey("dbo.Consultants", t => t.ConsultantId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.ConsultantId)
                .Index(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SkillScoringMatrixCells", "SubstituteSkill_SkillId", "dbo.Skills");
            DropForeignKey("dbo.SkillScoringMatrixCells", "DesiredSkill_SkillId", "dbo.Skills");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.GradeScoringMatrixCells", "SubstituteGrade_GradeId", "dbo.Grades");
            DropForeignKey("dbo.GradeScoringMatrixCells", "DesiredGrade_GradeId", "dbo.Grades");
            DropForeignKey("dbo.ConsultantSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.ConsultantSkills", "ConsultantId", "dbo.Consultants");
            DropForeignKey("dbo.Consultants", "GradeId", "dbo.Grades");
            DropIndex("dbo.ConsultantSkills", new[] { "SkillId" });
            DropIndex("dbo.ConsultantSkills", new[] { "ConsultantId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SkillScoringMatrixCells", new[] { "SubstituteSkill_SkillId" });
            DropIndex("dbo.SkillScoringMatrixCells", new[] { "DesiredSkill_SkillId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Projects", new[] { "ClientId" });
            DropIndex("dbo.GradeScoringMatrixCells", new[] { "SubstituteGrade_GradeId" });
            DropIndex("dbo.GradeScoringMatrixCells", new[] { "DesiredGrade_GradeId" });
            DropIndex("dbo.Consultants", new[] { "ProjectId" });
            DropIndex("dbo.Consultants", new[] { "GradeId" });
            DropTable("dbo.ConsultantSkills");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SkillScoringMatrixCells");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Projects");
            DropTable("dbo.GradeScoringMatrixCells");
            DropTable("dbo.Skills");
            DropTable("dbo.Grades");
            DropTable("dbo.Consultants");
            DropTable("dbo.Clients");
        }
    }
}
