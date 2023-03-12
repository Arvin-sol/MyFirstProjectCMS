using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Services;

namespace MyFirstProjectCMS.Areas.Admin.Controllers
{
    [Authorize]
    public class BlogGroupsController : Controller
    {
        private IBlogGroupRepository blogGroupRepository;
        MyProjectContext db = new MyProjectContext();
        public BlogGroupsController()
        {
            blogGroupRepository = new BlogGroupRepository(db);
        }

        // GET: Admin/BlogGroups
        public ActionResult Index()
        {
            return View(blogGroupRepository.getAll());
        }

        // GET: Admin/BlogGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogGroup blogGroup = blogGroupRepository.GetById(id.Value);
            if (blogGroup == null)
            {
                return HttpNotFound();
            }
            return View(blogGroup);
        }

        // GET: Admin/BlogGroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/BlogGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,GroupTitle")] BlogGroup blogGroup)
        {
            if (ModelState.IsValid)
            {
                blogGroupRepository.Create(blogGroup);
                blogGroupRepository.Save();
                return RedirectToAction("Index");
            }

            return PartialView(blogGroup);
        }

        // GET: Admin/BlogGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogGroup blogGroup = blogGroupRepository.GetById(id.Value);
            if (blogGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(blogGroup);
        }

        // POST: Admin/BlogGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupTitle")] BlogGroup blogGroup)
        {
            if (ModelState.IsValid)
            {
                blogGroupRepository.Edit(blogGroup);
                blogGroupRepository.Save();
                return RedirectToAction("Index");
            }
            return PartialView(blogGroup);
        }

        // GET: Admin/BlogGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogGroup blogGroup = blogGroupRepository.GetById(id.Value);
            if (blogGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(blogGroup);
        }

        // POST: Admin/BlogGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            blogGroupRepository.DeleteById(id);
            blogGroupRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                blogGroupRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
