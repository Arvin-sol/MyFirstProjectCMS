using DataLayer.Context;
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
    public class AdminLoginsController : Controller
    {
        private MyProjectContext db = new MyProjectContext();
        private IAdminLoginRepository loginRepository;
        public AdminLoginsController()
        {
            loginRepository = new AdminLoginRepository(db);
        }
        // GET: AdminLogins
        public ActionResult Index()
        {
            return View(loginRepository.GetAll());
        }

        // GET: AdminLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogins = loginRepository.GetById(id.Value);
            if (adminLogins == null)
            {
                return HttpNotFound();
            }
            return View(adminLogins);
        }

        // GET: AdminLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginID,UserName,Email,Password")] AdminLogin adminLogins)
        {
            if (ModelState.IsValid)
            {
                loginRepository.Create(adminLogins);
                loginRepository.Save();
                return RedirectToAction("Index");
            }

            return View(adminLogins);
        }

        // GET: AdminLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogins = loginRepository.GetById(id.Value);
            if (adminLogins == null)
            {
                return HttpNotFound();
            }
            return View(adminLogins);
        }

        // POST: AdminLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginID,UserName,Email,Password")] AdminLogin adminLogins)
        {
            if (ModelState.IsValid)
            {
                loginRepository.Edit(adminLogins);
                loginRepository.Save();
                return RedirectToAction("Index");
            }
            return View(adminLogins);
        }

        // GET: AdminLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogins = loginRepository.GetById(id.Value);
            if (adminLogins == null)
            {
                return HttpNotFound();
            }
            return View(adminLogins);
        }

        // POST: AdminLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminLogin adminLogins = loginRepository.GetById(id);
            loginRepository.DeleteById(id);
            loginRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                loginRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}