namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GallerysDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        URL = c.String(nullable: false),
                        ShortDescription = c.String(nullable: false),
                        BlogText = c.String(nullable: false),
                        Tag = c.String(),
                        Visit = c.Int(nullable: false),
                        ImageName = c.String(),
                        CreatDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.GalleryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Galleries");
        }
    }
}
