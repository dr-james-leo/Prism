namespace Prism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClientToProjects : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Projects", "ClientId");
            AddForeignKey("dbo.Projects", "ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Clients");
            DropIndex("dbo.Projects", new[] { "ClientId" });
        }
    }
}
