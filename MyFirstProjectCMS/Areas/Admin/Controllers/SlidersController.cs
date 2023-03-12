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
    public class SlidersController : Controller
    {
        private ISliderRepository sliderRepository;
        private MyProjectContext db = new MyProjectContext();

        public SlidersController()
        {
            sliderRepository = new SliderRepository(db);
        }

        // GET: Admin/Sliders
        public ActionResult Index()
        {
            return View(sliderRepository.GetAll());
        }

        // GET: Admin/Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = sliderRepository.GetById(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SliderViewModel SliderVM)
        {
            if (ModelState.IsValid)
            {
                Slider Slider = new Slider() 
                { 
                    SliderId = SliderVM.SliderId,
                    EndSlider = SliderVM.EndSlider,
                    ImageName= SliderVM.ImageName,
                    IsActive= SliderVM.IsActive,
                    SliderText= SliderVM.SliderText,
                    SliderURL= SliderVM.SliderURL,
                    StardSlider= SliderVM.StardSlider,
                    Title = SliderVM.Title
                };
                if (SliderVM.ImageUpload != null)
                {
                    Slider.ImageName = Guid.NewGuid() + Path.GetExtension(SliderVM.ImageUpload.FileName);
                    SliderVM.ImageUpload.SaveAs(Server.MapPath("/Images/Sliders/" + Slider.ImageName));
                }
                sliderRepository.Create(Slider);
                sliderRepository.Save();
                return RedirectToAction("Index");
            }

            return View(SliderVM);
        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SliderViewModel slider = sliderRepository.GetByIdVM(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SliderViewModel SliderVM)
        {
            if (ModelState.IsValid)
            {
                Slider Slider = new Slider()
                {

                    SliderId= SliderVM.SliderId,
                    SliderText= SliderVM.SliderText,
                    SliderURL= SliderVM.SliderURL,
                    StardSlider= SliderVM.StardSlider,
                    Title = SliderVM.Title,
                    EndSlider = SliderVM.EndSlider,
                    ImageName = SliderVM.ImageName,
                    IsActive = SliderVM.IsActive,
                };
                if (SliderVM.ImageUpload != null)
                {
                    if (Slider.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/Sliders/" + Slider.ImageName));
                    }
                    Slider.ImageName = Guid.NewGuid() + Path.GetExtension(SliderVM.ImageUpload.FileName);
                    SliderVM.ImageUpload.SaveAs(Server.MapPath("/Images/Sliders/" + Slider.ImageName));
                }
                sliderRepository.Edit(Slider);
                sliderRepository.Save();
                return RedirectToAction("Index");
            }
            return View(SliderVM);
        }

        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = sliderRepository.GetById(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Slider slider= sliderRepository.GetById(id);
            if (slider.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/Images/Sliders/" + slider.ImageName));
            }
            sliderRepository.DeleteById(id);
            sliderRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                sliderRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
