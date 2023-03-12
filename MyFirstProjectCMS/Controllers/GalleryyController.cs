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
    public class GalleryyController : Controller
    {
        private IGalleryRepository galleryRepository;
        private MyProjectContext db = new MyProjectContext();
        public GalleryyController()
        {
            galleryRepository = new GalleryRepository(db);
        }

        // GET: Galleryy
        [Route("GalleyProject/{id}")]
        public ActionResult GalleryProject(int id = 1)
        {
            int take = 6;
            ViewBag.CurrentBlog = id;
            ViewBag.GalleryCount = galleryRepository.CountGallery() / take;
            var getArchive = galleryRepository.ArchiveGallery(id);
            return View(getArchive);

        }
        [Route("GalleryProjectSinglePage/{id}")]
        public ActionResult GalleryProjectSinglePage(int id)
        {
            int blogid = 1;
            ViewBag.CurrentBlog = blogid;

            var gallery = galleryRepository.GetById(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            gallery.Visit += 1;
            galleryRepository.Edit(gallery);
            galleryRepository.Save();
            return View(gallery);
        }
    }
}