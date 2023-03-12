using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class BlogConfig:EntityTypeConfiguration<Blog>
    {
        public BlogConfig()
        {
            ToTable("Blog", "Blogs");
            HasRequired(x => x.BlogGroup).WithMany(x => x.Blogs).HasForeignKey(x => x.GroupId).WillCascadeOnDelete(false);

        }
    }
}
