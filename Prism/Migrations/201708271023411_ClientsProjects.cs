namespace Prism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientsProjects : DbMigration
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
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 3),
                        Name = c.String(nullable: false, maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Client_ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId, cascadeDelete: true)
                .Index(t => t.Client_ClientId);
            
            AddColumn("dbo.Consultants", "Project_ProjectId", c => c.Int());
            CreateIndex("dbo.Consultants", "Project_ProjectId");
            AddForeignKey("dbo.Consultants", "Project_ProjectId", "dbo.Projects", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultants", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Projects", new[] { "Client_ClientId" });
            DropIndex("dbo.Consultants", new[] { "Project_ProjectId" });
            DropColumn("dbo.Consultants", "Project_ProjectId");
            DropTable("dbo.Projects");
            DropTable("dbo.Clients");
        }
    }
}
