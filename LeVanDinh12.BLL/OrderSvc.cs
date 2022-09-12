using LeVanDinh12.Common.BLL;
using LeVanDinh12.Common.Rsp;
using LeVanDinh12.Common.Req;
using LeVanDinh12.DAL;
using LeVanDinh12.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.Json;

namespace LeVanDinh12.BLL
{
    public  class OrderSvc: GenericSvc<OrderRep, Order>
    {
		#region -- Overrides --
        private FlowerOrderRep flowerOrderRep = new FlowerOrderRep();
        private AnonymouseRep anonymouseRep = new AnonymouseRep();
		private FlowerRep flowerRep = new FlowerRep();

		public override SingleRsp Read(int id)
		{
			var rsq = new SingleRsp();
			rsq.Data = _rep.Read(id);
			return rsq;
		}

		#endregion

		#region -- Methods --



		#endregion

		public SingleRsp GetOrders()
        {
            var rsp = new SingleRsp();

            rsp.Data = _rep.GetOrders();

            return rsp;
        }
		public SingleRsp GetOrdersById(int id)
		{
			var rsp = new SingleRsp();
			var order = _rep.Read(id);
			if (order == null)
			{
				rsp.SetError("Order not found");
				return rsp;
			}
			else
			{
				rsp.Data = order;
			}
			return rsp;
		}

		public SingleRsp CreateOrder(CreateOrderReq req)
		{
			var rsp = new SingleRsp();
			var total = 0;
			var anonymouse = anonymouseRep.Read(req.AnonymousId);
			if (anonymouse == null)
			{
				rsp.SetError("Anonymouse not found");
				return rsp;
			}else{
				var order = new Order();
				order.AnonymousId = req.AnonymousId;
				order.PaidAt = null;
				order.ShippingCost = req.ShippingCost;
				order.Note = req.Note;
				_rep.Create(order);
				foreach (var flowerReq in req.Flowers)
				{
					var flower = flowerRep.Read(flowerReq.FlowerId);
					if (flower == null)
					{
						rsp.SetError("Flower not found");
						return rsp;
					}
					else
					{
						var FlowerOrder = new FlowerOrder();
						FlowerOrder.OrderId = order.Id;
						FlowerOrder.FlowerId = flowerReq.FlowerId;
						FlowerOrder.Quantity = flowerReq.Quantity;
						FlowerOrder.UnitPrice = flower.UnitPrice;
						flowerOrderRep.Create(FlowerOrder);
						total += flowerReq.Quantity * FlowerOrder.UnitPrice;
					}
				}
				rsp.Data = new { order, total };
				}
			return rsp;
		}
		public SingleRsp UpdateOrder(int id, UpdateOrderReq req)
		{
			var rsp = new SingleRsp();
			var order = _rep.Read(id);
			if (order == null)
			{
				rsp.SetError("Order not found");
				return rsp;
			}
			else
			{
				var anonymouse = anonymouseRep.Read(req.AnonymousId);
				if(anonymouse == null)
				{
					rsp.SetError("Anonymouse not found");
					return rsp;
				}
				else
				{
					order.AnonymousId = req.AnonymousId;
					order.PaidAt = req.PaidAt;
					order.ShippingCost = req.ShippingCost;
					order.Note = req.Note;
					_rep.Update(order);
					rsp.Data = order;
				}
			}
			return rsp;
		}

		public SingleRsp Payment(int id)
		{
			var rsp = new SingleRsp();
			var order = _rep.Read(id);
			if (order == null)
			{
				rsp.SetError("Order not found");
				return rsp;
			}
			else
			{
				order.PaidAt = DateTime.Now;
				_rep.Update(order);
				rsp.Data = order;
			}
			return rsp;
		}
		public SingleRsp GetFlowerInOrder(int id)
		{
			var rsp = new SingleRsp();
			var order = _rep.Read(id);
			if (order == null)
			{
				rsp.SetError("Order not found");
				return rsp;
			}
			else
			{
				var flowerOrders = flowerOrderRep.GetFlowerOrdersByOrderId(id);
				if (flowerOrders == null )
				{
					rsp.SetError("FlowerOrder not found");
					return rsp;
				}
				else
				{
					var flowers = new List<Flower>();
					foreach (var flower in flowerOrders)
					{
						var flower1 = flowerRep.Read((int)flower.FlowerId);
						flowers.Add(flower1);
					}
					rsp.Data = flowers;
				}
			}
			
			return rsp;
		}
		public SingleRsp addFLowerToOrder(int id, CreateFlowerOrderReq req)
		{
			var rsp = new SingleRsp();
			var order = _rep.Read(id);
			if (order == null)
			{
				rsp.SetError("Order not found");
				return rsp;
			}
			else
			{
				var flower = flowerRep.Read(req.FlowerId);
				// find flowerOrder by flowerId and orderId
				if (flower == null)
				{
					rsp.SetError("Flower not found");
						return rsp;
				}
				else
				{
					var flowerOrder = flowerOrderRep.Find(req.FlowerId, id);
					if (flowerOrder == null)						{
						var FlowerOrder = new FlowerOrder();
						FlowerOrder.OrderId = order.Id;
						FlowerOrder.FlowerId = req.FlowerId;
						FlowerOrder.Quantity = req.Quantity;
						FlowerOrder.UnitPrice = flower.UnitPrice;
						flowerOrderRep.Create(FlowerOrder);
					}
					else
					{
						flowerOrder.Quantity += req.Quantity;
						flowerOrderRep.Update(flowerOrder);
					}				

			}
			return rsp;
			}
		}
		
		public SingleRsp RemoveFlowerFromOrder(int id, int flowerId)
		{
			var rsp = new SingleRsp();
			var order = _rep.Read(id);
			if (order == null)
			{
				rsp.SetError("Order not found");
				return rsp;
			}
			else
			{
				var flower = flowerRep.Read(flowerId);
				if (flower == null)
				{
					rsp.SetError("Flower not found");
					return rsp;
				}
				else
				{
					var flowerOrder = flowerOrderRep.Find(flowerId, id);
					if (flowerOrder == null)
					{
						rsp.SetError("Flower not in order");
						return rsp;
					}
					else
					{
						flowerOrderRep.DeleteFlowerOrder(flower.Id, order.Id);
					}
				}
			}
			return rsp;
		}

		public SingleRsp DeleteOrder(int id)
		{
			var rsp = new SingleRsp();
			var order = _rep.Read(id);
			if (order == null)
			{
				rsp.SetError("Order not found");
				return rsp;
			}
			else
			{
				_rep.DeleteOrder(id);
			}
			return rsp;
		}
	}
}
