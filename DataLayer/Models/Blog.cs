using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Display(Name = "گروه بندی وبلاگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int GroupId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "توضیح مخنصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "متن اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string BlogText { get; set; }

        [Display(Name = "بازدید")]
        public int Visit { get; set; }

        [Display(Name = "نام تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "برچسب ها")]
        public string Tag { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd  h:mm}")]
        
        public DateTime CreateDate { get; set; }

        public virtual BlogGroup BlogGroup { get; set; } 
        public virtual ICollection<BlogComment> BlogComments { get; set; }
    }
}
