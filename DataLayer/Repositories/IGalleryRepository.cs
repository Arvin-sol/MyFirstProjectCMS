using DataLayer.Models;
using DataLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IGalleryRepository:IDisposable
    {
        IEnumerable<Gallery> GetAll();
        IEnumerable<Gallery> ArchiveGallery(int id = 1);
        int CountGallery();
        Gallery GetById(int GalleryId);
        GalleryViewModel GetByIdForVM(int galleryId);
        bool Create(Gallery galleryProject);
        bool Edit(Gallery galleryProject);
        bool DeleteById(int GalleryId);
        void Save();
    }
}
