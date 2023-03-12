using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer.Models
{
    public class Footer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "توضیح کوتاه درباره شرکت")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string ShortDescriptionAboutForm { get; set; }
        [Display(Name = "تصویر لوگو")]
        public string ImageName { get; set; }
    }
}
