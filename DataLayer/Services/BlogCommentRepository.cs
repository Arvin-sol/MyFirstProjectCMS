using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer.Services
{
    public class BlogCommentRepository:IBlogCommentRepository
    {
        private MyProjectContext db;
        public BlogCommentRepository(MyProjectContext context)
        {
            this.db = context;
        }
        public IEnumerable<BlogComment> GetAll()
        {
            var blogComment = db.BlogComments.Include(x => x.Blog).ToList();
            return blogComment;
        }
        public IEnumerable<BlogComment> GetCommentByBlogId(int blogId)
        {
            return db.BlogComments.Where(c => c.BlogId == blogId);
        }

        public BlogComment GetById(int commentid)
        {
            var getID = db.BlogComments.Find(commentid);
            return getID;
        }
        public bool Create(BlogComment comment)
        {
            try
            {
                var AddToComment = db.BlogComments.Add(comment);
                return true;
            }
            catch
            {
                throw new Exception("عملیات افزودن کامنت با خطا مواجه شد");
            }
        }
        public bool DeleteById(int CommentId)
        {
            try
            {
                BlogComment GetId = GetById(CommentId);
                db.BlogComments.Remove(GetId);
                return true;

            }
            catch
            {
                throw new Exception("عملیات حذف کامنت با خطا مواجه شد");
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
