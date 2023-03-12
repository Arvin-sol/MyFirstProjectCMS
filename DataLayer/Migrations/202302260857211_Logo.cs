namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Logo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logoes",
                c => new
                {
                    LogoId = c.Int(nullable: false, identity: true),
                    LogoTile = c.String(nullable: false),
                    ImageName = c.String(),
                })
                .PrimaryKey(t => t.LogoId);

        }

        public override void Down()
        {
            DropTable("dbo.Logoes");
        }
    }
}
