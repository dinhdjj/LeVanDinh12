using LeVanDinh12.Common.DAL;
using LeVanDinh12.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LeVanDinh12.Common.Rsp;

namespace LeVanDinh12.DAL
{
    public class FlowerOrderRep : GenericRep<FlowerFlowerContext, FlowerOrder>
    {
        public FlowerOrderRep()
        {

        }
        public IQueryable<FlowerOrder> GetFlowerOrdersByOrderId(int orderId)
        {
            return Context.FlowerOrders.Where(u => u.OrderId == orderId);
        }

        public FlowerOrder Find(int flowerId, int orderId)
        {
            return All.FirstOrDefault(f => f.FlowerId == flowerId && f.OrderId == orderId);
        }

        public SingleRsp UpdateFlowerOrder(FlowerOrder FlowerOrder)
        {
            var res = new SingleRsp();
            using (var context = new FlowerFlowerContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var f = context.FlowerOrders.Update(FlowerOrder);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp DeleteFlowerOrder(long flowerId, long orderId)
        {
            var res = new SingleRsp();
            var FlowerOrder = Context.FlowerOrders.FirstOrDefault(f => f.FlowerId == flowerId && f.OrderId == orderId);
            Context.FlowerOrders.Remove(FlowerOrder);
            Context.SaveChanges();
            return res;
        }

    }
}
