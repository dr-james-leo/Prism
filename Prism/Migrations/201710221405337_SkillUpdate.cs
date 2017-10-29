namespace Prism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SkillConsultants", newName: "ConsultantSkills");
            DropPrimaryKey("dbo.ConsultantSkills");
            AddPrimaryKey("dbo.ConsultantSkills", new[] { "Consultant_ConsultantId", "Skill_SkillId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ConsultantSkills");
            AddPrimaryKey("dbo.ConsultantSkills", new[] { "Skill_SkillId", "Consultant_ConsultantId" });
            RenameTable(name: "dbo.ConsultantSkills", newName: "SkillConsultants");
        }
    }
}
