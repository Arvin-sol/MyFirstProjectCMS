using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace DataLayer.Models.ViewModels
{
    public class FooterViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "توضیح کوتاه درباره شرکت")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string ShortDescriptionAboutFirm { get; set; }
        [Display(Name = "تصویر لوگو")]
        public string ImageName { get; set; }
        [Display(Name = "تصویر لوگو ")]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
