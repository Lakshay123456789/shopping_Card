namespace shappingCardInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RollName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoleMasters");
        }
    }
}
