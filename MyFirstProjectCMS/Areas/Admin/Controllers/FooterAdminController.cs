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
    public class FooterAdminController : Controller
    {
        private IFooterRepository footerRepository;

        private MyProjectContext db = new MyProjectContext();
        public FooterAdminController()
        {
            footerRepository = new FooterRepository(db);
        }
        // GET: Admin/Logos
        public ActionResult Index()
        {
            return View(footerRepository.GetAll());
        }

        // GET: Admin/Logos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footer footer = footerRepository.GetById(id.Value);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // GET: Admin/logos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/logos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FooterViewModel footerVM)
        {
            if (ModelState.IsValid)
            {
                var getcount = footerRepository.CountFooter();
                if (getcount >= 1)
                {
                    ModelState.AddModelError("", "در این بخش از مدیریت فوتر تنها می توانید یک تصویر را درج نمایید");
                    return RedirectToAction("Index");
                }

                Footer footer = new Footer()
                {
                    Id = footerVM.Id,
                    Title = footerVM.Title,
                    ImageName = footerVM.ImageName,
                    ShortDescriptionAboutForm = footerVM.ShortDescriptionAboutFirm
                };
                if (footerVM.ImageUpload != null)
                {
                    footer.ImageName = Guid.NewGuid() + Path.GetExtension(footerVM.ImageUpload.FileName);
                    footerVM.ImageUpload.SaveAs(Server.MapPath("/Images/" + footer.ImageName));
                }


                footerRepository.Create(footer);

                footerRepository.Save();


                return RedirectToAction("Index");
            }

            return View(footerVM);
        }

        // GET: Admin/Logos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterViewModel footer = footerRepository.GetByIdForVM(id.Value);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: Admin/Logos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FooterViewModel footerVM)
        {
            if (ModelState.IsValid)
            {
                Footer footer = new Footer()
                {
                    Id = footerVM.Id,
                    Title = footerVM.Title,
                    ImageName = footerVM.ImageName,
                    ShortDescriptionAboutForm = footerVM.ShortDescriptionAboutFirm
                };
                if (footerVM.ImageUpload != null)
                {
                    if (footer.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/" + footer.ImageName)); ;
                    }
                    footer.ImageName = Guid.NewGuid() + Path.GetExtension(footerVM.ImageUpload.FileName);
                    footerVM.ImageUpload.SaveAs(Server.MapPath("/Images/" + footer.ImageName));
                }


                footerRepository.Edit(footer);
                footerRepository.Save();
                return RedirectToAction("Index");
            }
            return View(footerVM);
        }

        // GET: Admin/Logos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footer footer = footerRepository.GetById(id.Value);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: Admin/Logos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Footer footer = footerRepository.GetById(id);
            if (footer.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/Images/" + footer.ImageName));
            }
            footerRepository.DeleteById(id);
            footerRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                footerRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}