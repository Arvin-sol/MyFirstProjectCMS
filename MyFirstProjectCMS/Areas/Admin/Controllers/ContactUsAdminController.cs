using DataLayer.Context;
using DataLayer.Models.ViewModels;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyFirstProjectCMS.Areas.Admin.Controllers
{
    [Authorize]
    public class ContactUsAdminController : Controller
    {
        private IContactUsRepository contactUsRepository;

        private MyProjectContext db = new MyProjectContext();
        public ContactUsAdminController()
        {
            contactUsRepository = new ContactUsRepository(db);
        }
        // GET: Admin/Logos
        public ActionResult Index()
        {
            return View(contactUsRepository.GetAll());
        }

        // GET: Admin/Logos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUs contactUs = contactUsRepository.GetById(id.Value);
            if (contactUs == null)
            {
                return HttpNotFound();
            }
            return View(contactUs);
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
        public ActionResult Create(ContactUsViewModel contactVM)
        {
            if (ModelState.IsValid)
            {
                var getcount = contactUsRepository.CountContactUs();
                if (getcount >= 1)
                {
                    ModelState.AddModelError("", "در این بخش از مدیریت تماس با ما تنها می توانید یک تصویر را درج نمایید");
                    return RedirectToAction("Index");
                }

                ContactUs contact = new ContactUs()
                {
                    Id = contactVM.Id,
                    Location = contactVM.Location,
                    Email = contactVM.Email,
                    PhoneNumber = contactVM.PhoneNumber
                };
                contactUsRepository.Create(contact);
                contactUsRepository.Save();


                return RedirectToAction("Index");
            }

            return View(contactVM);
        }

        // GET: Admin/Logos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUsViewModel contact = contactUsRepository.GetByIdForVM(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Admin/Logos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactUsViewModel contactVM)
        {
            if (ModelState.IsValid)
            {
                ContactUs contact = new ContactUs()
                {
                    Id = contactVM.Id,
                    Location = contactVM.Location,
                    Email = contactVM.Email,
                    PhoneNumber = contactVM.PhoneNumber
                };
                contactUsRepository.Edit(contact);
                contactUsRepository.Save();
                return RedirectToAction("Index");
            }
            return View(contactVM);
        }

        // GET: Admin/Logos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUs contact = contactUsRepository.GetById(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Admin/Logos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactUs contact = contactUsRepository.GetById(id);

            contactUsRepository.DeleteById(id);
            contactUsRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                contactUsRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}