namespace Prism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GradeScoringMatrixCells", "SubstituteGrade_GradeId", "dbo.Grades");
            DropForeignKey("dbo.GradeScoringMatrixCells", "DesiredGrade_GradeId", "dbo.Grades");
            DropIndex("dbo.GradeScoringMatrixCells", new[] { "SubstituteGrade_GradeId" });
            DropIndex("dbo.GradeScoringMatrixCells", new[] { "DesiredGrade_GradeId" });
            DropTable("dbo.GradeScoringMatrixCells");
        }
    }
}
