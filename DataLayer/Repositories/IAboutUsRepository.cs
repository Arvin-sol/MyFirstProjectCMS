using DataLayer.Models;
using DataLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IAboutUsRepository:IDisposable
    {
        IEnumerable<AboutUs> GetAll();
        AboutUs GetById(int aboutId);
        AboutUsViewModel GetByIdForVM(int aboutID);
        bool Create(AboutUs aboutUs);
        bool Edit(AboutUs aboutUs);
        int CountAboutUs();
        bool DeleteById(int aboutID);
        void Save();
    }
}
