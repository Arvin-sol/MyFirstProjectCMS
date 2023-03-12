using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class BlogComment
    {
        [Key]
        public int CommentId { get; set; }

        [Display(Name="وبلاگ")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public int BlogId { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name ="ایمیل")]
        public string Email { get; set; }

        [Display(Name = "وبسایت")]
        public string Website { get; set; }

        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CommentText { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
