﻿using System;
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
    public class AboutUsViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "درباره ما")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string AboutUsText { get; set; }
        [Display(Name = "تصویر ")]
        public string ImageName { get; set; }
        [Display(Name = "تصویر ")]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
