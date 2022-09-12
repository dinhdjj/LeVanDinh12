using LeVanDinh12.Common.BLL;
using LeVanDinh12.Common.Rsp;
using LeVanDinh12.Common.Req;
using LeVanDinh12.DAL;
using LeVanDinh12.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeVanDinh12.BLL
{
    public  class AnonymouseSvc: GenericSvc<AnonymouseRep, Anonymouse>
    {
		#region -- Overrides --

		public override SingleRsp Read(int id)
		{
			var rsq = new SingleRsp();

			rsq.Data = _rep.Read(id);
			return rsq;
		}

		#endregion

		#region -- Methods --



		#endregion

		public SingleRsp GetAnonymouses()
        {
            var rsp = new SingleRsp();

            rsp.Data = _rep.GetAnonymouses();

            return rsp;
        }

		public SingleRsp ReadByPhone(string phone)
        {
           	var rsp = new SingleRsp();

			var anonymouse = _rep.FindByPhone(phone);

			if (anonymouse == null) 
			{
				rsp.Code = "404";
				rsp.SetError("Anonymouse not found");
				return rsp;
			}

			rsp.Data = anonymouse;

			return rsp;
        }

		public SingleRsp CreateAnonymouse(CreateAnonymouseReq req)
		{
			var rsp = new SingleRsp();

			var anonymouse = _rep.FindByPhone(req.Phone);

			if (anonymouse != null)
			{
				rsp.Code = "422";
				rsp.SetError("Anonymouse phone was exists");
				return rsp;
			}

			anonymouse = new Anonymouse();
			anonymouse.Phone = req.Phone;
			anonymouse.Name = req.Name;
			anonymouse.Address = req.Address;

			_rep.Create(anonymouse);

			rsp.Data = anonymouse;

			return rsp;
		}

		public SingleRsp UpdateAnonymouse(int id, UpdateAnonymouseReq req)
		{
			var rsp = new SingleRsp();

			var anonymouse = _rep.Read(id);

			if (anonymouse == null) 
			{
				rsp.Code = "404";
				rsp.SetError("Anonymouse not found");
				return rsp;
			}

			if (anonymouse.Phone != req.Phone) 
			{
				if (_rep.FindByPhone(req.Phone) != null)
				{
					rsp.Code = "422";
					rsp.SetError("Phone was exists");
					return rsp;
				}
			}

			anonymouse.Phone = req.Phone;
			anonymouse.Name = req.Name;
			anonymouse.Address = req.Address;

			_rep.Update(anonymouse);

			rsp.Data = anonymouse;

			return rsp;
		}

		public SingleRsp DeleteAnonymouse(int id)
		{
			var rsp = new SingleRsp();

			var anonymouse = _rep.Read(id);

			if (anonymouse == null) 
			{
				rsp.Code = "404";
				rsp.SetError("Anonymouse not found");
				return rsp;
			}

			_rep.Delete(anonymouse);

			rsp.Data = anonymouse;

			return rsp;
		}
	}
}
