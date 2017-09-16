namespace Prism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToProjects : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Projects", name: "Client_ClientId", newName: "ClientId");
            RenameIndex(table: "dbo.Projects", name: "IX_Client_ClientId", newName: "IX_ClientId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Projects", name: "IX_ClientId", newName: "IX_Client_ClientId");
            RenameColumn(table: "dbo.Projects", name: "ClientId", newName: "Client_ClientId");
        }
    }
}
