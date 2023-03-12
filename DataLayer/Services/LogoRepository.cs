using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Models.ViewModels;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DataLayer.Services
{
    public class LogoRepository : ILogoRepository
    {
        private MyProjectContext db;

        public LogoRepository(MyProjectContext db1)
        {
            this.db = db1;
        }

        public IEnumerable<Logo> GetAll()
        {
            var getLogo = db.Logoes.ToList();
            return getLogo;
        }
        public Logo GetById(int LogoId)
        {
            var getId = db.Logoes.Find(LogoId);
            return getId;
        }
        public LogoViewModel GetByIdVM(int LogoId)
        {
            var getId = db.Logoes.Where(x => x.LogoId == LogoId).Select(x => new LogoViewModel()
            {
                LogoId = x.LogoId,
                LogoTile = x.LogoTile,
                ImageName = x.ImageName,
            }).FirstOrDefault();
            return getId;
        }
        public int LogoCount()
        {
            var getCount = db.Logoes.Count();
            return getCount;
        }


        public bool Create(Logo logo)
        {
            try
            {
                var AddToSlider = db.Logoes.Add(logo);
                return true;
            }
            catch
            {
                throw new Exception("عملیات افزودن لوگو با خطا مواجه شد");
            }
        }

        public bool DeleteById(int LogoId)
        {
            try
            {
                var GetId = GetById(LogoId);
                db.Logoes.Remove(GetId);
                return true;
            }
            catch
            {
                throw new Exception("عملیات حذف لوگو با خطا مواجه شد");
            }
        }

        public bool Update(Logo logo)
        {
            try
            {
                db.Entry(logo).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات ویرایش لوگو با خطا مواجه شد");
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
