using System;
using System.Collections.Generic;
using System.Text;

namespace LeVanDinh12.Common.Req
{
    public class UpdateFlowerReq
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string MainImageUrl { get; set; }
    }
}
