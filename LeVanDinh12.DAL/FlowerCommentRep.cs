using LeVanDinh12.Common.DAL;
using LeVanDinh12.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LeVanDinh12.Common.Rsp;

namespace LeVanDinh12.DAL
{
    public class FlowerCommentRep : GenericRep<FlowerFlowerContext, FlowerComment>
    {
        public FlowerCommentRep()
        {

        }

        public override FlowerComment Read(int id)
        {
            return All.FirstOrDefault(f => f.Id == id);
        }

        public IQueryable<FlowerComment> GetFlowerCommentsByFlowerId(int flowerId)
        {
            return All.Where(f => f.FlowerId == flowerId);
        }

        public SingleRsp CreateFlowerComment(FlowerComment flowerComment)
        {
            var res = new SingleRsp();
            using (var context = new FlowerFlowerContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var f = context.FlowerComments.Add(flowerComment);
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

        public SingleRsp UpdateFlowerComment(FlowerComment flowerComment)
        {
            var res = new SingleRsp();
            using (var context = new FlowerFlowerContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var f = context.FlowerComments.Update(flowerComment);
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
        public long DeleteFlowerCommentById(long id)
        {
            var context = new FlowerFlowerContext();
            var f = context.FlowerComments.Find(id);
            context.FlowerComments.Remove(f);
            context.SaveChanges();
            return f.Id;
        }
    }
}
