using System;
using System.Collections.Generic;

#nullable disable

namespace LeVanDinh12.DAL.Models
{
    public partial class CategoryPost
    {
        public long CategoryId { get; set; }
        public long PostId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Post Post { get; set; }
    }
}
