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
    public class HomeController : Controller
    {
        private ISliderRepository sliderRepository;
        private ILogoRepository logoRepository;
        private IAboutUsRepository aboutUsRepository;
        private IContactUsRepository contactUsRepository;

        private MyProjectContext db = new MyProjectContext();
        public HomeController()
        {
            logoRepository = new LogoRepository(db);
            sliderRepository = new SliderRepository(db);
            aboutUsRepository= new AboutUsRepository(db);
            contactUsRepository= new ContactUsRepository(db);
        }


        public ActionResult Index()
        {
            int id = 1;
            ViewBag.CurrentBlog = id;
            return View();
        }
        [Route("ContactUs")]
        public ActionResult ContactUs()
        {
            var getContactUs = contactUsRepository.GetAll();
            return View(getContactUs);
        }
        [Route("AboutUs")]
        public ActionResult AboutUs()
        {
            int id = 1;
            ViewBag.CurrentBlog = id;
            var getAboutUs = aboutUsRepository.GetAll();
            return View(getAboutUs);
        }
        public ActionResult Slider()
        {
            return PartialView(sliderRepository.GetAll());
        }
        public ActionResult LogoAC()
        {
            return PartialView(logoRepository.GetAll());
        }

    }
}