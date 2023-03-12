using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IBlogCommentRepository:IDisposable
    {
        IEnumerable<BlogComment> GetAll();
        IEnumerable<BlogComment> GetCommentByBlogId(int blogId);
        BlogComment GetById(int commentid);
        bool Create(BlogComment comment);
        bool DeleteById(int CommentId);
        void Save();
    }
}
