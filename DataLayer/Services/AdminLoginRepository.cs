using DataLayer.Context;
using DataLayer.Migrations;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using AdminLogin = DataLayer.Models.AdminLogin;

namespace DataLayer.Services
{
    public class AdminLoginRepository : IAdminLoginRepository
    {
        private MyProjectContext db;

        public AdminLoginRepository(MyProjectContext db)
        {
            this.db = db;
        }
        public IEnumerable<AdminLogin> GetAll()
        {
            var getList = db.AdminLogins.ToList();
            return getList;
        }
        public AdminLogin GetById(int id)
        {
            var getId = db.AdminLogins.Find(id);
            return getId;
        }
        public bool Create(AdminLogin logins)
        {
            try
            {
                var Add = db.AdminLogins.Add(logins);
                return true;
            }
            catch
            {
                throw new Exception("عملیات افزودن  با خطا مواجه شد");
            }
        }
        public bool Edit(AdminLogin logins)
        {
            try
            {
                db.Entry(logins).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات ویرایش  با خطا مواجه شد");
            }
        }

        public bool DeleteById(int loginId)
        {
            try
            {
                var GetId = GetById(loginId);
                db.AdminLogins.Remove(GetId);
                return true;
            }
            catch
            {
                throw new Exception("عملیات حذف  با خطا مواجه شد");
            }
        }

        public bool IsExistUser(string email, string password)
        {
            return db.AdminLogins.Any(u => u.Email == email && u.Password == password);
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
