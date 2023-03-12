namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blog : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Blogs.Blog", "ShortDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Blogs.Blog", "ShortDescription", c => c.String(nullable: false));
        }
    }
}
