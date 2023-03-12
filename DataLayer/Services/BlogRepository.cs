using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Models.ViewModels;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Hierarchy;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DataLayer.Services
{
    public class BlogRepository : IBlogRepository
    {
        private MyProjectContext db;
        public BlogRepository(MyProjectContext cont)
        {
            this.db = cont;
        }

        public IEnumerable<Blog> getAll()
        {
            var getlist = db.Blogs.ToList();
            return getlist;
        }
        public IEnumerable<Blog> LastBlogs(int take=3)
        {
            var getLastBlogs = db.Blogs.OrderByDescending(b=>b.CreateDate).Take(take);
            return getLastBlogs;
        }
        public IEnumerable<Blog> Search(string SearchParameter)
        {
            return db.Blogs.Where(b=>b.BlogText.Contains(SearchParameter) || b.Tag.Contains(SearchParameter) || b.ShortDescription.Contains(SearchParameter) || b.Title.Contains(SearchParameter)).Distinct();
        }

        public Blog GetById(int blogId)
        {
            var getById = db.Blogs.Find(blogId);
            return getById;
        }

        public BlogViewModels GetByIdVM(int blogId)
        {
            var getById = db.Blogs.Where(e=>e.BlogId == blogId).Select(x=>new BlogViewModels()
            {
                BlogId = x.BlogId,
                GroupId = x.GroupId,
                Title = x.Title,
                BlogText = x.BlogText,
                ShortDescription = x.ShortDescription,
                ImageName = x.ImageName,
                CreateDate = x.CreateDate,
                Visit = x.Visit,
                Tag= x.Tag,
            }).FirstOrDefault();
            return getById;
        }
        public IEnumerable<Blog> ArchiveBlogs(int id = 1)
        {
            int take = 6;
            int skip = (id - 1) * take;
            int count = CountBlogs();
            return (db.Blogs.OrderBy(p => p.CreateDate).Skip(skip).Take(take)).ToList();
        }
        public int CountBlogs()
        {
            return (db.Blogs.Count());
        }
        public bool Create(Blog blog)
        {
            try
            {
                var creatBlog = db.Blogs.Add(blog);
                return true;
            }
            catch
            {
                throw new Exception("عملیات با خطا مواجه شد");
            }
        }
        public bool Edit(Blog blog)
        {
            try
            {
                db.Entry(blog).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات با خطا مواجه شد");
            }
        }
        public bool DeleteById(int blogId)
        {
           var getId = GetById(blogId);
            db.Blogs.Remove(getId);
            return true;
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }

    }
}
