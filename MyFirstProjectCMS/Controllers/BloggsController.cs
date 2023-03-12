using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Services;
using Microsoft.SqlServer.Server;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MyFirstProjectCMS.Controllers
{
    public class BloggsController : Controller
    {
        private IBlogRepository blogRepository;
        private MyProjectContext db = new MyProjectContext();
        private IBlogCommentRepository commentRepository;
        public BloggsController()
        {
            blogRepository = new BlogRepository(db);
            commentRepository = new BlogCommentRepository(db);
        }
        [Route("Archive/{id}")]
        public ActionResult ArchiveBlog(int id = 0)
        {
            int take = 6;
            ViewBag.CurrentBlog = id;
            ViewBag.BlogCount = blogRepository.CountBlogs() / take;
            var getArchive = blogRepository.ArchiveBlogs(id);
            return View(getArchive);
        }
        // GET: Blogs
        public ActionResult LastBlogs()
        {
            return PartialView(blogRepository.LastBlogs());
        }
        public ActionResult LeftCornerLastBlogs()
        {
            return PartialView(blogRepository.LastBlogs());
        }

        [Route("Blogs/{id}")]
        public ActionResult ShowBlog(int id)
        {
            var blogs = blogRepository.GetById(id);
            if(blogs == null)
            {
                return HttpNotFound();
            }
            blogs.Visit += 1;
            blogRepository.Edit(blogs);
            blogRepository.Save();

            return View(blogs);
        }

        public ActionResult AddComment(int id , string name , string email , string comment)
        {
            BlogComment addComment = new BlogComment()
            {
                BlogId = id,
                Name = name,
                Email = email,
                CommentText = comment,
                CreateDate= DateTime.Now,
            };
            commentRepository.Create(addComment);
            commentRepository.Save();
            return PartialView("ShowComment",commentRepository.GetCommentByBlogId(id));
        }

        public ActionResult ShowComment(int id )
        {
            return PartialView(commentRepository.GetCommentByBlogId(id));
        }
    }
}