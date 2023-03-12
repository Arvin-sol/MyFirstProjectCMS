using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class BlogGroup
    {
        [Key]
        public int GroupId { get; set; }

        [Display(Name="عنوان گروه")]
        [MaxLength(150)]
        public string GroupTitle { get; set; }

        public virtual ICollection<Blog> Blogs { get; set;}
    }
}
