namespace Outfit_Picker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationsecond : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accessories", "AccessoryName", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Bottoms", "BottomName", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Shoes", "ShoeName", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Tops", "TopName", c => c.String(nullable: false, maxLength: 40));
            DropColumn("dbo.Accessories", "Name");
            DropColumn("dbo.Bottoms", "Name");
            DropColumn("dbo.Shoes", "Name");
            DropColumn("dbo.Tops", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tops", "Name", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Shoes", "Name", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Bottoms", "Name", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Accessories", "Name", c => c.String(nullable: false, maxLength: 40));
            DropColumn("dbo.Tops", "TopName");
            DropColumn("dbo.Shoes", "ShoeName");
            DropColumn("dbo.Bottoms", "BottomName");
            DropColumn("dbo.Accessories", "AccessoryName");
        }
    }
}
