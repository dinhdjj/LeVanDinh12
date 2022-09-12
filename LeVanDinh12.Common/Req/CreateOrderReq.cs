using System;
using System.Collections.Generic;
using System.Text;

namespace LeVanDinh12.Common.Req
{
	public class CreateOrderReq
	{
		public string Note { get; set; }
        public int AnonymousId { get; set; }
		public int ShippingCost { get; set; }
		public CreateFlowerOrderReq[] Flowers { get; set; }
	}
}
