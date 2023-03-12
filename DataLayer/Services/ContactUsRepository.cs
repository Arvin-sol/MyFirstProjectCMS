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
    public class ContactUsRepository:IContactUsRepository
    {
        private MyProjectContext db;
        public ContactUsRepository(MyProjectContext db)
        {
            this.db = db;
        }
        public IEnumerable<ContactUs> GetAll()
        {
            var getList = db.ContactUs.ToList();
            return getList;
        }

        public ContactUs GetById(int Id)
        {
            var getID = db.ContactUs.Find(Id);
            return getID;
        }
        public bool Create(ContactUs contactUs)
        {
            try
            {
                var AddToContactUs = db.ContactUs.Add(contactUs);
                return true;
            }
            catch
            {
                throw new Exception("عملیات افزودن  با خطا مواجه شد");
            }
        }

        public bool DeleteById(int Id)
        {
            try
            {
                var GetId = GetById(Id);
                db.ContactUs.Remove(GetId);
                return true;
            }
            catch
            {
                throw new Exception("عملیات حذف  با خطا مواجه شد");
            }
        }


        public bool Edit(ContactUs contactUs)
        {
            try
            {
                db.Entry(contactUs).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات ویرایش  با خطا مواجه شد");
            }
        }



        public ContactUsViewModel GetByIdForVM(int Id)
        {
            var getId = db.ContactUs.Where(x => x.Id == Id).Select(x => new ContactUsViewModel()
            {
                Id = x.Id,
                Location = x.Location,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email
            }).FirstOrDefault();
            return getId;
        }
        public int CountContactUs()
        {
            var getCount = db.ContactUs.Count();
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
