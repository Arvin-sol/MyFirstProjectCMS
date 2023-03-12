using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace DataLayer.Models.ViewModels
{
    public class SliderViewModel
    {
        [Key]
        public int SliderId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "توضیح")]
        [MaxLength(40)]
        public string SliderText { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StardSlider { get; set; }

        [Display(Name = "تاریخ پابان")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndSlider { get; set; }

        [Display(Name = "وضعیت ")]
        public bool IsActive { get; set; }

        [Display(Name = "لینک ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Url(ErrorMessage = "آدرس وارد شده معتبر نیست")]
        public string SliderURL { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }

    }
}
