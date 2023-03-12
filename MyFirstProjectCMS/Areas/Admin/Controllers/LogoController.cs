using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Models.ViewModels;
using DataLayer.Repositories;
using DataLayer.Services;

namespace MyFirstProjectCMS.Areas.Admin.Controllers
{
    [Authorize]
    public class LogoController : Controller
    {
        private ILogoRepository logorepository;
        private MyProjectContext db = new MyProjectContext();

        public LogoController()
        {
            logorepository = new LogoRepository(db);
        }

        // GET: Admin/Logoes
        public ActionResult Index()
        {
            return View(logorepository.GetAll());
        }

        // GET: Admin/Logoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logo logo = logorepository.GetById(id.Value);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // GET: Admin/Logoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Logoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LogoViewModel LogoVM)
        {
            if (ModelState.IsValid)
            {
                var getCount = logorepository.LogoCount();
                if (getCount >= 1)
                {
                    ModelState.AddModelError("", "در این بخش از مدیریت اسلایدر تنها می توانید یک تصویر را درج نمایید");
                    return RedirectToAction("Index");
                }
                Logo logo = new Logo()
                {
                    LogoId = LogoVM.LogoId,
                    ImageName = LogoVM.ImageName,
                    LogoTile = LogoVM.LogoTile
                };
                if (LogoVM.ImageUpload != null)
                {
                    logo.ImageName = Guid.NewGuid() + Path.GetExtension(LogoVM.ImageUpload.FileName);
                    LogoVM.ImageUpload.SaveAs(Server.MapPath("/Images/" + logo.ImageName));
                }
                logorepository.Create(logo);
                logorepository.Save();
                return RedirectToAction("Index");
            }

            return View(LogoVM);
        }

        // GET: Admin/Logoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogoViewModel LogoVM = logorepository.GetByIdVM(id.Value);
            if (LogoVM == null)
            {
                return HttpNotFound();
            }
            return View(LogoVM);
        }

        // POST: Admin/Logoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LogoViewModel logoVM)
        {
            if (ModelState.IsValid)
            {
                Logo logo = new Logo()
                {
                    LogoId = logoVM.LogoId,
                    LogoTile = logoVM.LogoTile,
                    ImageName = logoVM.ImageName
                };

                if (logoVM.ImageUpload != null)
                {
                    if (logo.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/" + logo.ImageName)); ;
                    }
                    logo.ImageName = Guid.NewGuid() + Path.GetExtension(logoVM.ImageUpload.FileName);
                    logoVM.ImageUpload.SaveAs(Server.MapPath("/Images/" + logo.ImageName));
                }

                logorepository.Update(logo);
                logorepository.Save();
                return RedirectToAction("Index");
            }
            return View(logoVM);
        }

        // GET: Admin/Logoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logo logo = logorepository.GetById(id.Value);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // POST: Admin/Logoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logo logo = logorepository.GetById(id);
            if (logo.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/Images/" + logo.ImageName));
            }
            logorepository.DeleteById(id);
            logorepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                logorepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
