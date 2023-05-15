namespace shappingCardInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleMasterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.RoleMasters", t => t.RoleMasterId, cascadeDelete: true)
                .Index(t => t.RoleMasterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleMasterId", "dbo.RoleMasters");
            DropIndex("dbo.Users", new[] { "RoleMasterId" });
            DropTable("dbo.Users");
        }
    }
}
