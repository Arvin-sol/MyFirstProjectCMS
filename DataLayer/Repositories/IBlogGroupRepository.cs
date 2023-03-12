using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IBlogGroupRepository:IDisposable
    {
        IEnumerable<BlogGroup> getAll();
        BlogGroup GetById(int groupId);
        bool Create(BlogGroup blogGroup);
        bool Edit(BlogGroup blogGroup);
        bool DeleteById(int groupId);
        void Save();
    }
}
