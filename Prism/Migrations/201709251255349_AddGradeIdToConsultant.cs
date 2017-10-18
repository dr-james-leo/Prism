namespace Prism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGradeIdToConsultant : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Consultants", name: "Grade_GradeId", newName: "GradeId");
            RenameIndex(table: "dbo.Consultants", name: "IX_Grade_GradeId", newName: "IX_GradeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Consultants", name: "IX_GradeId", newName: "IX_Grade_GradeId");
            RenameColumn(table: "dbo.Consultants", name: "GradeId", newName: "Grade_GradeId");
        }
    }
}
