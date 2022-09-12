using System;
using System.Collections.Generic;
using System.Text;

namespace LeVanDinh12.Common.Req
{
	public class UpdateOrderReq
    {
        public string Note { get; set; }
        public int ShippingCost { get; set; }
        public int AnonymousId { get; set; }
        public DateTime PaidAt { get; set; }
    }
}
