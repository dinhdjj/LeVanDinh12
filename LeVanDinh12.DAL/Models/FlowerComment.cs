using System;
using System.Collections.Generic;

#nullable disable

namespace LeVanDinh12.DAL.Models
{
    public partial class FlowerComment
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long FlowerId { get; set; }
        public long AnonymousId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Anonymouse Anonymous { get; set; }
        public virtual Flower Flower { get; set; }
    }
}
