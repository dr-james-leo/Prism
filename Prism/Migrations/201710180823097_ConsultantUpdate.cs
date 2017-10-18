namespace Prism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsultantUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consultants", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.Consultants", new[] { "Project_ProjectId" });
            RenameColumn(table: "dbo.Consultants", name: "Project_ProjectId", newName: "ProjectId");
            AlterColumn("dbo.Consultants", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Consultants", "ProjectId");
            AddForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Consultants", new[] { "ProjectId" });
            AlterColumn("dbo.Consultants", "ProjectId", c => c.Int());
            RenameColumn(table: "dbo.Consultants", name: "ProjectId", newName: "Project_ProjectId");
            CreateIndex("dbo.Consultants", "Project_ProjectId");
            AddForeignKey("dbo.Consultants", "Project_ProjectId", "dbo.Projects", "ProjectId");
        }
    }
}
