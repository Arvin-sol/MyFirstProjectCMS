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
    public class SliderRepository : ISliderRepository
    {
        private MyProjectContext db;
        public SliderRepository(MyProjectContext cont)
        {
            this.db = cont;
        }


        public IEnumerable<Slider> GetAll()
        {
            var getlist = db.Sliders.ToList();
            return getlist;
        }
        public Slider GetById(int SliderId)
        {
            var getById = db.Sliders.Find(SliderId);
            return getById;
        }

        public SliderViewModel GetByIdVM(int SliderId)
        {
            var getById = db.Sliders.Where(e => e.SliderId == SliderId).Select(x => new SliderViewModel()
            {
                SliderId = x.SliderId,
                SliderURL = x.SliderURL,
                EndSlider = x.EndSlider,
                StardSlider = x.StardSlider,
                IsActive = x.IsActive,
                SliderText = x.SliderText,
                Title = x.Title,
                ImageName = x.ImageName,

            }).FirstOrDefault();
            return getById;
        }
        public bool Create(Slider slider)
        {
            try
            {
                var createSlider = db.Sliders.Add(slider);
                return true;
            }
            catch
            {
                throw new Exception("عملیات با خطا مواجه شد");
            }
        }
        public bool Edit(Slider slider)
        {
            try
            {
                db.Entry(slider).State = EntityState.Modified;
                return true;
            }
            catch
            {
                throw new Exception("عملیات با خطا مواجه شد");
            }
        }

        public bool DeleteById(int SliderId)
        {
            var getId = GetById(SliderId);
            db.Sliders.Remove(getId);
            return true;
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
