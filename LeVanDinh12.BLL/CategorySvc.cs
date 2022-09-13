using LeVanDinh12.Common.BLL;
using LeVanDinh12.Common.Req;
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
            var rsq = new SingleRsp();
            rsq.Data = _rep.Read(id);

            return rsq;
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

        public SingleRsp GetCategories()
        {
            var rsp = new SingleRsp();
            rsp.Data = _rep.GetCategories();
            return rsp;
        }

        public SingleRsp CreateCategory(CreateCategoryReq req)
        {
            var rsp = new SingleRsp();
            var c = _rep.FindByName(req.Name);
            if(c == null)
            {
                rsp.Code = "422";
                rsp.SetError("Category name is exsits");
                return rsp;
            }
            c = new Category();
            c.Name = req.Name;
            c.Description = req.Description;
            _rep.Create(c);
            rsp.Data = c;

            return rsp;
        }

        public SingleRsp UpdateCategory(UpdateCategoryReq req)
        {
            var rsp = new SingleRsp();
            var u = _rep.FindByName(req.oldName);
            if (u == null)
            {
                rsp.Code = "422";
                rsp.SetError("Category name is exsits");
                return rsp;
            }

            if (u.Name != req.oldName)
            {
                rsp.Code = "422";
                rsp.SetError("Old name is invalid");
                return rsp;
            }

            u.Name = req.newName;
            _rep.Update(u);

            return rsp;
        }

        public SingleRsp DeleteCategory(int id)
        {
            var de = new SingleRsp();
            var category = _rep.Read(id);
            if(category == null)
            {
                de.Code = "404";
                de.SetError("Category not found");
                return de;
            }
            _rep.DeleteCate(category);
            de.Data = category;
            return de;
        }

        #region --Methods --
        public CategorySvc() { }

        #endregion

    }
}
