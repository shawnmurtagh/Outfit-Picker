namespace Outfit_Picker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        PhotoPath = c.String(),
                        Type = c.String(nullable: false, maxLength: 40),
                        ColorID = c.Int(nullable: false),
                        SeasonID = c.Int(nullable: false),
                        OccasionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessoryID)
                .ForeignKey("dbo.Colors", t => t.ColorID)
                .ForeignKey("dbo.Occasions", t => t.OccasionID)
                .ForeignKey("dbo.Seasons", t => t.SeasonID)
                .Index(t => t.ColorID)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.Occasions",
                c => new
                    {
                        OccasionID = c.Int(nullable: false, identity: true),
                        OccasionName = c.String(),
                    })
                .PrimaryKey(t => t.OccasionID);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        SeasonID = c.Int(nullable: false, identity: true),
                        SeasonName = c.String(),
                    })
                .PrimaryKey(t => t.SeasonID);
            
            CreateTable(
                "dbo.Bottoms",
                c => new
                    {
                        BottomID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        PhotoPath = c.String(),
                        Type = c.String(nullable: false, maxLength: 40),
                        ColorID = c.Int(nullable: false),
                        SeasonID = c.Int(nullable: false),
                        OccasionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BottomID)
                .ForeignKey("dbo.Colors", t => t.ColorID)
                .ForeignKey("dbo.Occasions", t => t.OccasionID)
                .ForeignKey("dbo.Seasons", t => t.SeasonID)
                .Index(t => t.ColorID)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
            CreateTable(
                "dbo.Outfits",
                c => new
                    {
                        OutfitID = c.Int(nullable: false, identity: true),
                        OutfitName = c.String(),
                        TopID = c.Int(nullable: false),
                        BottomID = c.Int(nullable: false),
                        ShoeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OutfitID)
                .ForeignKey("dbo.Bottoms", t => t.BottomID)
                .ForeignKey("dbo.Shoes", t => t.ShoeID)
                .ForeignKey("dbo.Tops", t => t.TopID)
                .Index(t => t.TopID)
                .Index(t => t.BottomID)
                .Index(t => t.ShoeID);
            
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        ShoeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        PhotoPath = c.String(),
                        Type = c.String(nullable: false, maxLength: 40),
                        ColorID = c.Int(nullable: false),
                        SeasonID = c.Int(nullable: false),
                        OccasionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoeID)
                .ForeignKey("dbo.Colors", t => t.ColorID)
                .ForeignKey("dbo.Occasions", t => t.OccasionID)
                .ForeignKey("dbo.Seasons", t => t.SeasonID)
                .Index(t => t.ColorID)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
            CreateTable(
                "dbo.Tops",
                c => new
                    {
                        TopID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        PhotoPath = c.String(),
                        Type = c.String(nullable: false, maxLength: 40),
                        ColorID = c.Int(nullable: false),
                        SeasonID = c.Int(nullable: false),
                        OccasionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TopID)
                .ForeignKey("dbo.Colors", t => t.ColorID)
                .ForeignKey("dbo.Occasions", t => t.OccasionID)
                .ForeignKey("dbo.Seasons", t => t.SeasonID)
                .Index(t => t.ColorID)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Outfits", "TopID", "dbo.Tops");
            DropForeignKey("dbo.Tops", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Tops", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Tops", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Outfits", "ShoeID", "dbo.Shoes");
            DropForeignKey("dbo.Shoes", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Shoes", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Shoes", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Outfits", "BottomID", "dbo.Bottoms");
            DropForeignKey("dbo.Bottoms", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Bottoms", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Bottoms", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Accessories", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Accessories", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Accessories", "ColorID", "dbo.Colors");
            DropIndex("dbo.Tops", new[] { "OccasionID" });
            DropIndex("dbo.Tops", new[] { "SeasonID" });
            DropIndex("dbo.Tops", new[] { "ColorID" });
            DropIndex("dbo.Shoes", new[] { "OccasionID" });
            DropIndex("dbo.Shoes", new[] { "SeasonID" });
            DropIndex("dbo.Shoes", new[] { "ColorID" });
            DropIndex("dbo.Outfits", new[] { "ShoeID" });
            DropIndex("dbo.Outfits", new[] { "BottomID" });
            DropIndex("dbo.Outfits", new[] { "TopID" });
            DropIndex("dbo.Bottoms", new[] { "OccasionID" });
            DropIndex("dbo.Bottoms", new[] { "SeasonID" });
            DropIndex("dbo.Bottoms", new[] { "ColorID" });
            DropIndex("dbo.Accessories", new[] { "OccasionID" });
            DropIndex("dbo.Accessories", new[] { "SeasonID" });
            DropIndex("dbo.Accessories", new[] { "ColorID" });
            DropTable("dbo.Tops");
            DropTable("dbo.Shoes");
            DropTable("dbo.Outfits");
            DropTable("dbo.Bottoms");
            DropTable("dbo.Seasons");
            DropTable("dbo.Occasions");
            DropTable("dbo.Colors");
            DropTable("dbo.Accessories");
        }
    }
}
