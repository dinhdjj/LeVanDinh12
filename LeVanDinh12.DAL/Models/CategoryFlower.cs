using System;
using System.Collections.Generic;

#nullable disable

namespace LeVanDinh12.DAL.Models
{
    public partial class CategoryFlower
    {
        public long CategoryId { get; set; }
        public long FlowerId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Flower Flower { get; set; }
    }
}
