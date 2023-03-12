namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Slider1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sliders", "StardSlider", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Sliders", "EndSlider", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sliders", "EndSlider", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sliders", "StardSlider", c => c.DateTime(nullable: false));
        }
    }
}
