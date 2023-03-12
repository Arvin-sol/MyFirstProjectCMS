using DataLayer.Models;
using DataLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ISliderRepository:IDisposable
    {
        IEnumerable<Slider> GetAll();
        Slider GetById(int SliderId);
        SliderViewModel GetByIdVM(int SliderId);
        bool Create(Slider slider);
        bool Edit(Slider slider);
        bool DeleteById(int SliderId);
        void Save();
    }
}
