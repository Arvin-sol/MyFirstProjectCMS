using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class BlogGroupRepository : IBlogGroupRepository
    {
        private MyProjectContext db;
        public BlogGroupRepository(MyProjectContext Mycontext)
        {
            this.db = Mycontext;
        }

        public IEnumerable<BlogGroup> getAll()
        {
            var list = db.BlogGroups.ToList();
            return list;
        }
        public BlogGroup GetById(int groupId)
        {
            var GetId = db.BlogGroups.Find(groupId);
            return GetId;
        }
        public bool Create(BlogGroup blogGroup)
        {
            try
            {
                var AddToBlogGroup = db.BlogGroups.Add(blogGroup);
                return true;
            }
            catch
            {
                throw new Exception("عملیات با خطا مواجه شد");
            }
        }

        public bool Edit(BlogGroup blogGroup)
        {
            try
            {
                db.Entry(blogGroup).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات با خطا مواجه شد");
            }
        }
        public bool DeleteById(int groupId)
        {
            try
            {
                var GetId = GetById(groupId);
                db.BlogGroups.Remove(GetId);
                return true;
            }
            catch
            {
                throw new Exception("عملیات با خطا مواجه شد");
            }
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
