namespace TrainingManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Batches", "BatchCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Batches", "BatchCode", c => c.String());
        }
    }
}
