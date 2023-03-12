namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Slider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ImageName = c.String(),
                        SliderText = c.String(maxLength: 40),
                        StardSlider = c.DateTime(nullable: false),
                        EndSlider = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        SliderURL = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SliderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sliders");
        }
    }
}
