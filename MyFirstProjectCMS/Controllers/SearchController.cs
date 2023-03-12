using DataLayer.Context;
using DataLayer.Repositories;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstProjectCMS.Controllers
{
    public class SearchController : Controller
    {
        private IBlogRepository blogRepository;
        private MyProjectContext db = new MyProjectContext();
        public SearchController()
        {
            blogRepository =  new BlogRepository(db);
        }

        // GET: Search
        public ActionResult Index(string q , int id=1)
        {
            int take = 6;
            ViewBag.CurrentBlog = id;
            ViewBag.BlogCount = blogRepository.CountBlogs() / take;
            var getSearchResualt = blogRepository.Search(q);
            ViewBag.Name = q;
            return View(getSearchResualt);
        }
    }
}