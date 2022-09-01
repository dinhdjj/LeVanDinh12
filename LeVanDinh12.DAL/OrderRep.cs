using LeVanDinh12.Common.DAL;
using LeVanDinh12.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeVanDinh12.DAL
{
    public class OrderRep: GenericRep<FlowerFlowerContext, Order>
    {
        #region --overides--
        public override Order Read(int id)
        {
            var res = All.FirstOrDefault(p => p.Id == id);
            return res;
        }

        //public int Remove(int id)
        //{
        //    var m = All.First(i => i.Id == id);
        //    m = base.Delete(m);
        //    return m.Id;
        //}
        #endregion
    }
}
