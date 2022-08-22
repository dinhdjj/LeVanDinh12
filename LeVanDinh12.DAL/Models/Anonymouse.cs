using System;
using System.Collections.Generic;

#nullable disable

namespace LeVanDinh12.DAL.Models
{
    public partial class Anonymouse
    {
        public Anonymouse()
        {
            FlowerComments = new HashSet<FlowerComment>();
            Orders = new HashSet<Order>();
            PostComments = new HashSet<PostComment>();
        }

        public long Id { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<FlowerComment> FlowerComments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
    }
}
