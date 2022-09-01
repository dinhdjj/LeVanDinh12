using LeVanDinh12.Common.DAL;
using LeVanDinh12.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeVanDinh12.DAL
{
    public class CategoriesRep: GenericRep<FlowerFlowerContext, Category>
    {
        #region --Override--
        public override Category Read(int id)
        {
            return base.Read(id);
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.Id == id);
            m = base.Delete(m);
            return (int)m.Id;
        }
        #endregion

        #region --Methods--
        public CategoriesRep() { }
        #endregion
    }
}
