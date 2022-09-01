using LeVanDinh12.Common.BLL;
using LeVanDinh12.Common.Rsp;
using LeVanDinh12.DAL;
using LeVanDinh12.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeVanDinh12.BLL
{
    public class CategorySvc: GenericSvc<CategoriesRep, Category>
    {
        #region --Override--
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public override SingleRsp Update(Category m)
        {
            var res = new SingleRsp();
            var u = m.Id > 0 ? _rep.Read((int)m.Id) : _rep.Read(m.Description);
            if (u == null)
                res.SetError("EZ103", "No Data");
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }

        #endregion

        #region --Methods --
        public CategorySvc() { }

        #endregion

    }
}
