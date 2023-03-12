using DataLayer.Context;
using DataLayer.Models.ViewModels;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class FooterRepository:IFooterRepository
    {
        private MyProjectContext db;
        public FooterRepository(MyProjectContext db)
        {
            this.db = db;
        }
        public IEnumerable<Footer> GetAll()
        {
            var getList = db.Footers.ToList();
            return getList;
        }

        public Footer GetById(int Id)
        {
            var getId = db.Footers.Find(Id);
            return getId;
        }
        public bool Create(Footer footer)
        {
            try
            {
                var AddToFooter = db.Footers.Add(footer);
                return true;
            }
            catch
            {
                throw new Exception("عملیات افزودن فوتر با خطا مواجه شد");
            }
        }

        public bool DeleteById(int Id)
        {
            try
            {
                var GetId = GetById(Id);
                db.Footers.Remove(GetId);
                return true;
            }
            catch
            {
                throw new Exception("عملیات حذف  با خطا مواجه شد");
            }
        }


        public bool Edit(Footer footer)
        {
            try
            {
                db.Entry(footer).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات ویرایش  با خطا مواجه شد");
            }
        }



        public FooterViewModel GetByIdForVM(int Id)
        {
            var getId = db.Footers.Where(x => x.Id == Id).Select(x => new FooterViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                ImageName = x.ImageName,
                ShortDescriptionAboutFirm = x.ShortDescriptionAboutForm
            }).FirstOrDefault();
            return getId;
        }
        public int CountFooter()
        {
            var getCount = db.Footers.Count();
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
