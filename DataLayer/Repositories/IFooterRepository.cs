using DataLayer.Models.ViewModels;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IFooterRepository:IDisposable
    {
        IEnumerable<Footer> GetAll();
        Footer GetById(int Id);
        FooterViewModel GetByIdForVM(int Id);
        bool Create(Footer footer);
        bool Edit(Footer footer);
        bool DeleteById(int Id);
        void Save();
        int CountFooter();
    }
}
