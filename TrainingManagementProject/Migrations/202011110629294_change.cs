namespace TrainingManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        BatchCode = c.String(),
                        CourseId = c.Int(nullable: false),
                        BatchStartDate = c.DateTime(nullable: false),
                        BatchNoOfSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false),
                        CourseName = c.String(nullable: false),
                        CourseDescription = c.String(),
                        CourseDuration = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Batches", "CourseId", "dbo.Courses");
            DropIndex("dbo.Batches", new[] { "CourseId" });
            DropTable("dbo.Courses");
            DropTable("dbo.Batches");
        }
    }
}
