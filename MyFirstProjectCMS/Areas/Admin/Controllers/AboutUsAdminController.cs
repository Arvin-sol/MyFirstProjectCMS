using DataLayer.Context;
using DataLayer.Models.ViewModels;
using DataLayer.Models;
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
    public class AboutUsAdminController : Controller
    {
        private IAboutUsRepository aboutUsRepository;
        private MyProjectContext db = new MyProjectContext();

        public AboutUsAdminController()
        {
            aboutUsRepository = new AboutUsRepository(db);
        }
        // GET: Admin/AboutUs
        public ActionResult Index()
        {
            return View(aboutUsRepository.GetAll());
        }

        // GET: Admin/AboutUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUs aboutUs = aboutUsRepository.GetById(id.Value);
            if (aboutUs == null)
            {
                return HttpNotFound();
            }
            return View(aboutUs);
        }

        // GET: Admin/logos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AboutUsViewModel aboutVM)
        {
            if (ModelState.IsValid)
            {
                var getcount = aboutUsRepository.CountAboutUs();
                if (getcount >= 1)
                {
                    ModelState.AddModelError("", "در این بخش از مدیریت درباره ما تنها می توانید یک تصویر را درج نمایید");
                    return RedirectToAction("Index");
                }

                AboutUs aboutUs = new AboutUs()
                {
                    Id = aboutVM.Id,
                    Title = aboutVM.Title,
                    AboutUsText = aboutVM.AboutUsText,
                    ImageName = aboutVM.ImageName,
                };
                if (aboutVM.ImageUpload != null)
                {
                    aboutUs.ImageName = Guid.NewGuid() + Path.GetExtension(aboutVM.ImageUpload.FileName);
                    aboutVM.ImageUpload.SaveAs(Server.MapPath("/Images/" + aboutUs.ImageName));
                }


                aboutUsRepository.Create(aboutUs);

                aboutUsRepository.Save();


                return RedirectToAction("Index");
            }

            return View(aboutVM);
        }

        // GET: Admin/AboutUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUsViewModel aboutUs = aboutUsRepository.GetByIdForVM(id.Value);
            if (aboutUs == null)
            {
                return HttpNotFound();
            }
            return View(aboutUs);
        }

        // POST: Admin/AboutUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AboutUsViewModel aboutVM)
        {
            if (ModelState.IsValid)
            {
                AboutUs aboutUs = new AboutUs()
                {
                    Id = aboutVM.Id,
                    Title = aboutVM.Title,
                    AboutUsText = aboutVM.AboutUsText,
                    ImageName = aboutVM.ImageName,
                };

                if (aboutVM.ImageUpload != null)
                {
                    if (aboutUs.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/" + aboutUs.ImageName)); ;
                    }
                    aboutUs.ImageName = Guid.NewGuid() + Path.GetExtension(aboutVM.ImageUpload.FileName);
                    aboutVM.ImageUpload.SaveAs(Server.MapPath("/Images/" + aboutUs.ImageName));
                }


                aboutUsRepository.Edit(aboutUs);
                aboutUsRepository.Save();
                return RedirectToAction("Index");
            }
            return View(aboutVM);
        }

        // GET: Admin/AboutUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUs aboutUs = aboutUsRepository.GetById(id.Value);
            if (aboutUs == null)
            {
                return HttpNotFound();
            }
            return View(aboutUs);
        }

        // POST: Admin/AboutUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutUs aboutUs = aboutUsRepository.GetById(id);
            if (aboutUs.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/Images/" + aboutUs.ImageName));
            }
            aboutUsRepository.DeleteById(id);
            aboutUsRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                aboutUsRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}