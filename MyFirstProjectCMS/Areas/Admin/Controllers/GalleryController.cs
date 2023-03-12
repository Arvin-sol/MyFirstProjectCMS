using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Models.ViewModels;
using DataLayer.Repositories;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyFirstProjectCMS.Areas.Admin.Controllers
{
    [Authorize]
    public class GalleryController : Controller
    {
        private IGalleryRepository galleryRepository;
        private MyProjectContext db = new MyProjectContext();
        public GalleryController()
        {
            galleryRepository = new GalleryRepository(db);  
        }
        public ActionResult Index()
        {
            var getList = galleryRepository.GetAll();
            return View(getList);
        }

        // GET: Admin/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery galleryProject = galleryRepository.GetById(id.Value);

            if (galleryProject == null)
            {
                return HttpNotFound();
            }
            return View(galleryProject);
        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProjectGallery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GalleryViewModel galleryVM)
        {
            if (ModelState.IsValid)
            {
                Gallery gallery = new Gallery()
                {
                    GalleryId = galleryVM.GalleryId,
                    ProjectName = galleryVM.ProjectName,
                    Location = galleryVM.Location,
                    URL = galleryVM.URL,
                    Title = galleryVM.Title,
                    ShortDescription = galleryVM.ShortDescription,
                    BlogText = galleryVM.BlogText,
                    ImageName = galleryVM.ImageName,
                    CreatDate = galleryVM.CreateDate,
                    Visit = galleryVM.Visit,
                    Tag = galleryVM.Tag

                };
                gallery.Visit = 0;
                if (galleryVM.ImageUpload != null)
                {
                    gallery.ImageName = Guid.NewGuid() + Path.GetExtension(galleryVM.ImageUpload.FileName);
                    galleryVM.ImageUpload.SaveAs(Server.MapPath("/Images/" + gallery.ImageName));
                }


                galleryRepository.Create(gallery);
                galleryRepository.Save();


                return RedirectToAction("Index");
            }

            return View(galleryVM);
        }

        // GET: Admin/projectGallery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryViewModel gallery = galleryRepository.GetByIdForVM(id.Value);

            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Admin/projectGallery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GalleryViewModel galleryVM)
        {
            if (ModelState.IsValid)
            {
                Gallery gallery = new Gallery()
                {
                    GalleryId = galleryVM.GalleryId,
                    ProjectName = galleryVM.ProjectName,
                    Location = galleryVM.Location,
                    URL = galleryVM.URL,
                    Title = galleryVM.Title,
                    ShortDescription = galleryVM.ShortDescription,
                    BlogText = galleryVM.BlogText,
                    ImageName = galleryVM.ImageName,
                    CreatDate = galleryVM.CreateDate,
                    Visit = galleryVM.Visit,
                    Tag = galleryVM.Tag
                };

                if (galleryVM.ImageUpload != null)
                {
                    if (gallery.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/" + gallery.ImageName));
                    }
                    gallery.ImageName = Guid.NewGuid() + Path.GetExtension(galleryVM.ImageUpload.FileName);
                    galleryVM.ImageUpload.SaveAs(Server.MapPath("/Images/" + gallery.ImageName));
                }


                galleryRepository.Edit(gallery);
                galleryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(galleryVM);
        }

        // GET: Admin/  projectGallery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = galleryRepository.GetById(id.Value);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Admin/ProjectGallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery gallery = galleryRepository.GetById(id);
            if (gallery.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/Images/" + gallery.ImageName));
            }
            galleryRepository.DeleteById(id);
            galleryRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                galleryRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}