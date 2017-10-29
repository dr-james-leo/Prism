namespace Prism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillUpdate1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ConsultantSkills", name: "Consultant_ConsultantId", newName: "ConsultantId");
            RenameColumn(table: "dbo.ConsultantSkills", name: "Skill_SkillId", newName: "SkillId");
            RenameIndex(table: "dbo.ConsultantSkills", name: "IX_Consultant_ConsultantId", newName: "IX_ConsultantId");
            RenameIndex(table: "dbo.ConsultantSkills", name: "IX_Skill_SkillId", newName: "IX_SkillId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ConsultantSkills", name: "IX_SkillId", newName: "IX_Skill_SkillId");
            RenameIndex(table: "dbo.ConsultantSkills", name: "IX_ConsultantId", newName: "IX_Consultant_ConsultantId");
            RenameColumn(table: "dbo.ConsultantSkills", name: "SkillId", newName: "Skill_SkillId");
            RenameColumn(table: "dbo.ConsultantSkills", name: "ConsultantId", newName: "Consultant_ConsultantId");
        }
    }
}
