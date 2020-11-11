namespace TrainingManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserPassword = c.String(nullable: false),
                        UserFirstName = c.String(nullable: false),
                        UserLastName = c.String(nullable: false),
                        UserDateOfJoining = c.DateTime(nullable: false),
                        UserEmailId = c.String(),
                        RoleId = c.Int(nullable: false),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
