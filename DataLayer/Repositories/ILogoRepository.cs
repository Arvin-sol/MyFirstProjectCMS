using DataLayer.Models;
using DataLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ILogoRepository : IDisposable
    {
        IEnumerable<Logo> GetAll();
        Logo GetById(int LogoId);
        LogoViewModel GetByIdVM(int LogoId);
        bool Create(Logo logo);
        bool Update(Logo logo);
        bool DeleteById(int LogoId);
        void Save();
        int LogoCount();

    }
}
