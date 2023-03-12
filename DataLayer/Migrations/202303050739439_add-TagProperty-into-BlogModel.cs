namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTagPropertyintoBlogModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("Blogs.Blog", "Tag", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Blogs.Blog", "Tag");
        }
    }
}
