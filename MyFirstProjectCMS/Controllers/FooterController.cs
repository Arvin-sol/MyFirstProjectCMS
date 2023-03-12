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
    public class FooterController : Controller
    {
        private IFooterRepository footerRepository;
        private IContactUsRepository contactUsRepository;
        private IBlogRepository blogRepository;

        MyProjectContext db = new MyProjectContext();
        public FooterController()
        {
            blogRepository = new BlogRepository(db);
            footerRepository = new FooterRepository(db);
            contactUsRepository = new ContactUsRepository(db);
        }
        // GET: Footer
        public ActionResult FooterSite()
        {
            var GetFooter = footerRepository.GetAll();
            return PartialView(GetFooter);
        }
        public ActionResult FooterContact()
        {
            var GetContact = contactUsRepository.GetAll();
            return PartialView(GetContact);
        }
        public ActionResult LastBlogsFooter()
        {         
            return PartialView(blogRepository.LastBlogs());
        }
    }
}