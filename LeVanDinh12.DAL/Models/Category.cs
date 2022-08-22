using System;
using System.Collections.Generic;

#nullable disable

namespace LeVanDinh12.DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryFlowers = new HashSet<CategoryFlower>();
            CategoryPosts = new HashSet<CategoryPost>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<CategoryFlower> CategoryFlowers { get; set; }
        public virtual ICollection<CategoryPost> CategoryPosts { get; set; }
    }
}
