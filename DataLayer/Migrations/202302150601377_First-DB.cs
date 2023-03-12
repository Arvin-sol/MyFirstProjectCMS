namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Blogs.BlogComment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        BlogId = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        CommentText = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("Blogs.Blog", t => t.BlogId)
                .Index(t => t.BlogId);
            
            CreateTable(
                "Blogs.Blog",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        ShortDescription = c.String(nullable: false),
                        BlogText = c.String(nullable: false),
                        Visit = c.Int(nullable: false),
                        ImageName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.BlogGroups", t => t.GroupId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.BlogGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Blogs.BlogComment", "BlogId", "Blogs.Blog");
            DropForeignKey("Blogs.Blog", "GroupId", "dbo.BlogGroups");
            DropIndex("Blogs.Blog", new[] { "GroupId" });
            DropIndex("Blogs.BlogComment", new[] { "BlogId" });
            DropTable("dbo.BlogGroups");
            DropTable("Blogs.Blog");
            DropTable("Blogs.BlogComment");
        }
    }
}
