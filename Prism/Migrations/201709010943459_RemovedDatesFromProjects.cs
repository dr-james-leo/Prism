namespace Prism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDatesFromProjects : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "StartDate");
            DropColumn("dbo.Projects", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
