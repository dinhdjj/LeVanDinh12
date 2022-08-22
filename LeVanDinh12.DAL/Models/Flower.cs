using System;
using System.Collections.Generic;

#nullable disable

namespace LeVanDinh12.DAL.Models
{
    public partial class Flower
    {
        public Flower()
        {
            CategoryFlowers = new HashSet<CategoryFlower>();
            FlowerComments = new HashSet<FlowerComment>();
            FlowerOrders = new HashSet<FlowerOrder>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string MainImageUrl { get; set; }
        public long UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CategoryFlower> CategoryFlowers { get; set; }
        public virtual ICollection<FlowerComment> FlowerComments { get; set; }
        public virtual ICollection<FlowerOrder> FlowerOrders { get; set; }
    }
}
