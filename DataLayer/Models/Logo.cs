using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer.Models
{
    public class Logo
    {
        public int LogoId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را ئارد کنید")]
        public string LogoTile { get; set; }

        [Display(Name = "تصویر لوگو")]
        public string ImageName { get; set; }

    }
}
