using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IAdminLoginRepository:IDisposable
    {
        IEnumerable<AdminLogin> GetAll();
        AdminLogin GetById(int id);
        bool Create (AdminLogin logins);
        bool Edit (AdminLogin logins);
        bool DeleteById (int loginId);
        void Save();
        bool IsExistUser(string userName , string password);
    }
}
