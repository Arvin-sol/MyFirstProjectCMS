using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Xml.Linq;

namespace DataLayer.Models.ViewModels
{
    public class GalleryViewModel
    {
        [Key]
        public int GalleryId { get; set; }
        [Display(Name = "نام پروژه")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public string ProjectName { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "لوکیشن")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string Location { get; set; }
        [Display(Name = "لینک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Url(ErrorMessage = "آدرس وارد شده معتبر نمی باشد")]
        public string URL { get; set; }

        [AllowHtml]
        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }
        [Display(Name = "جزئیات پروژه")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string BlogText { get; set; }
        [Display(Name = "برچسب ها")]
        public string Tag { get; set; }
        [Display(Name = "بازدید ")]
        public int Visit { get; set; }
        [Display(Name = "تصویر پروژه")]

        public string ImageName { get; set; }
        [Display(Name = "تاریخ انجام پروژه")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
        [Display(Name = "تصویر پروژه")]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
