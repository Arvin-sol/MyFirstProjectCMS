using DataLayer.Context;
using DataLayer.Models.ViewModels;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class AboutUsRepository:IAboutUsRepository
    {
        private MyProjectContext db;
        public AboutUsRepository(MyProjectContext db)
        {
            this.db = db;
        }

        public IEnumerable<AboutUs> GetAll()
        {
            var getList = db.AboutUs.ToList();
            return getList;
        }

        public AboutUs GetById(int aboutId)
        {
            var getId = db.AboutUs.Find(aboutId);
            return getId;
        }
        public bool Create(AboutUs aboutUs)
        {
            try
            {
                var AddToAboutUS = db.AboutUs.Add(aboutUs);
                return true;
            }
            catch
            {
                throw new Exception("عملیات افزودن درباره ما با خطا مواجه شد");
            }
        }

        public bool DeleteById(int aboutId)
        {
            try
            {
                var GetId = GetById(aboutId);
                db.AboutUs.Remove(GetId);
                return true;
            }
            catch
            {
                throw new Exception("عملیات حذف درباره ما با خطا مواجه شد");
            }
        }


        public bool Edit(AboutUs aboutUs)
        {
            try
            {
                db.Entry(aboutUs).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات ویرایش درباره ما با خطا مواجه شد");
            }
        }



        public AboutUsViewModel GetByIdForVM(int aboutID)
        {
            var getId = db.AboutUs.Where(x => x.Id == aboutID).Select(x => new AboutUsViewModel()
            {
                Id = x.Id,
                AboutUsText = x.AboutUsText,
                Title = x.Title,
                ImageName = x.ImageName,
            }).FirstOrDefault();
            return getId;
        }
        public int CountAboutUs()
        {
            var getCount = db.AboutUs.Count();
            return getCount;
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
