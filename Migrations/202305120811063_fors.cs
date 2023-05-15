namespace shappingCardInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Guid(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductPrice = c.Double(nullable: false),
                        ProductDescription = c.String(nullable: false),
                        ProductQuantity = c.Int(nullable: false),
                        ProductImage = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Products");
        }
    }
}
