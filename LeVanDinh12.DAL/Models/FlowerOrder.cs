using System;
using System.Collections.Generic;

#nullable disable

namespace LeVanDinh12.DAL.Models
{
    public partial class FlowerOrder
    {
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public long OrderId { get; set; }
        public long FlowerId { get; set; }

        public virtual Flower Flower { get; set; }
        public virtual Order Order { get; set; }
    }
}
