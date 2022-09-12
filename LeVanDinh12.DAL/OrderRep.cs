using LeVanDinh12.Common.DAL;
using LeVanDinh12.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LeVanDinh12.Common.Rsp;

namespace LeVanDinh12.DAL
{
    public class OrderRep : GenericRep<FlowerFlowerContext, Order>
    {
		#region -- Overrides --

		#endregion

		public override Order Read(int id)
		{
			return Context.Orders.Where(u => u.Id == id).FirstOrDefault();
		}
		public Order UpdateOrder(Order order)
		{
			var orderUpdate = Context.Orders.Find(order.Id);
			if (orderUpdate != null)
			{
				orderUpdate.AnonymousId = order.AnonymousId;
				orderUpdate.PaidAt = order.PaidAt;
				orderUpdate.ShippingCost = order.ShippingCost;
				orderUpdate.Note = order.Note;
				Context.SaveChanges();
			}
			return orderUpdate;
		}

		#region -- Methods --

		#endregion

		public IQueryable<Order> GetOrders()
        {
            return Context.Orders.Select(u=>u);
        }
		public SingleRsp DeleteOrder(int id)
		{
			var rsp = new SingleRsp();
			var order = Context.Orders.Find((long)id);
			if (order == null)
			{
				rsp.SetError("Order not found");
				return rsp;
			}
			else
			{
				Context.Orders.Remove(order);
				Context.SaveChanges();
			}
			return rsp;
		}
	}
}
