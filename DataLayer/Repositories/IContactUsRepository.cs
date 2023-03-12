using DataLayer.Models.ViewModels;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IContactUsRepository:IDisposable
    {
        IEnumerable<ContactUs> GetAll();
        ContactUs GetById(int Id);
        ContactUsViewModel GetByIdForVM(int Id);
        bool Create(ContactUs contactUs);
        bool Edit(ContactUs contactUs);
        bool DeleteById(int Id);
        void Save();
        int CountContactUs();
    }
}
