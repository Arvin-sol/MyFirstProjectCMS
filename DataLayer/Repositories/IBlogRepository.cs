using DataLayer.Models;
using DataLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IBlogRepository:IDisposable
    {
        IEnumerable<Blog> getAll();
        IEnumerable<Blog> Search(string SearchParameter);
        IEnumerable<Blog> LastBlogs(int take=3);
        IEnumerable<Blog> ArchiveBlogs(int id=1);
        int CountBlogs();

        Blog GetById(int blogId);
        BlogViewModels GetByIdVM(int blogId);

        bool Create(Blog blog);
        bool Edit(Blog blog);
        bool DeleteById(int blogId);
        void Save();
    }
}
