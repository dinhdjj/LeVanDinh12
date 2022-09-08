using LeVanDinh12.Common.DAL;
using LeVanDinh12.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LeVanDinh12.Common.Rsp;

namespace LeVanDinh12.DAL
{
    public class FlowerRep : GenericRep<FlowerFlowerContext, Flower>
    {
        public FlowerRep()
        {

        }
        #region --Override--
        public override Flower Read(int id)
        {
            return All.FirstOrDefault(f => f.Id == id);
        }
        #endregion

        #region --Methods--
        public IQueryable<Flower> GetFlowers()
        {
            return All;
        }

        public SingleRsp CreateFlower(Flower flower)
        {
            var res = new SingleRsp();
            using (var context = new FlowerFlowerContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var f = context.Flowers.Add(flower);
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

        public SingleRsp UpdateFlower(Flower flower)
        {
            var res = new SingleRsp();
            using (var context = new FlowerFlowerContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var f = context.Flowers.Update(flower);
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

        public long DeleteFlowerById(long id)
        {
            var context = new FlowerFlowerContext();
            var f = context.Flowers.Find(id);
            context.Flowers.Remove(f);
            context.SaveChanges();
            return f.Id;
        }
        #endregion
    }
}
