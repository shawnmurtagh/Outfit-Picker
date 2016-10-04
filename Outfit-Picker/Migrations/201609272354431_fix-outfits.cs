namespace Outfit_Picker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixoutfits : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accessories", "Outfit_OutfitID", c => c.Int());
            CreateIndex("dbo.Accessories", "Outfit_OutfitID");
            AddForeignKey("dbo.Accessories", "Outfit_OutfitID", "dbo.Outfits", "OutfitID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accessories", "Outfit_OutfitID", "dbo.Outfits");
            DropIndex("dbo.Accessories", new[] { "Outfit_OutfitID" });
            DropColumn("dbo.Accessories", "Outfit_OutfitID");
        }
    }
}
