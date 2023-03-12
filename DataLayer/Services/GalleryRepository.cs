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

namespace DataLayer.Services
{
    public class GalleryRepository : IGalleryRepository
    {
        private MyProjectContext db;
        public GalleryRepository(MyProjectContext db)
        {
            this.db = db;
        }

        public IEnumerable<Gallery> GetAll()
        {
            var getList = db.Gallerys.ToList();
            return getList;
        }

        public Gallery GetById(int GalleryId)
        {
            var getID = db.Gallerys.Find(GalleryId);
            return getID;
        }

        public GalleryViewModel GetByIdForVM(int galleryId)
        {
            var getId = db.Gallerys.Where(x => x.GalleryId == galleryId).Select(x => new GalleryViewModel()
            {
                GalleryId = x.GalleryId,
                ProjectName = x.ProjectName,
                Location = x.Location,
                URL = x.URL,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                BlogText = x.BlogText,
                ImageName = x.ImageName,
                CreateDate = x.CreatDate,
                Visit = x.Visit,
                Tag = x.Tag
            }).FirstOrDefault();
            return getId;
        }
        public IEnumerable<Gallery> ArchiveGallery(int id = 1)
        {
            int take = 6;
            int skip = (id - 1) * take;
            return (db.Gallerys.OrderBy(p => p.CreatDate).Skip(skip).Take(take).ToList());
        }

        public int CountGallery()
        {
            return (db.Gallerys.Count());
        }

        public bool Create(Gallery galleryProject)
        {
            try
            {
                var AddToGallery = db.Gallerys.Add(galleryProject);
                return true;
            }
            catch
            {
                throw new Exception("عملیات افزودن گالری با خطا مواجه شد");
            }
        }

        public bool DeleteById(int GalleryId)
        {
            try
            {
                var GetId = GetById(GalleryId);
                db.Gallerys.Remove(GetId);
                return true;
            }
            catch
            {
                throw new Exception("عملیات حذف گالری با خطا مواجه شد");
            }
        }

        public bool Edit(Gallery galleryProject)
        {
            try
            {
                db.Entry(galleryProject).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات ویرایش گالری با خطا مواجه شد");
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
