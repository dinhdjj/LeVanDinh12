using System;
using System.Collections.Generic;

#nullable disable

namespace LeVanDinh12.DAL.Models
{
    public partial class Order
    {
        public Order()
        {
            FlowerOrders = new HashSet<FlowerOrder>();
        }

        public long Id { get; set; }
        public string Note { get; set; }
        public long AnonymousId { get; set; }
        public int ShippingCost { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Anonymouse Anonymous { get; set; }
        public virtual ICollection<FlowerOrder> FlowerOrders { get; set; }
    }
}
