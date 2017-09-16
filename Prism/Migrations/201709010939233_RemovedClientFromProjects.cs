namespace Prism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedClientFromProjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Clients");
            DropIndex("dbo.Projects", new[] { "ClientId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Projects", "ClientId");
            AddForeignKey("dbo.Projects", "ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
        }
    }
}
