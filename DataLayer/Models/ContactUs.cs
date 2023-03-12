using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer.Models
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "لوکیشن")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string Location { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "آدرس وارد شده معتبر نمی باشد")]
        public string Email { get; set; }
        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public string PhoneNumber { get; set; }
    }
}
