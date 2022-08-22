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
    public  class UserSvc: GenericSvc<UserRep, User>
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

		public SingleRsp GetUsers()
        {
            var rsp = new SingleRsp();

            rsp.Data = _rep.GetUsers();

            return rsp;
        }

		public SingleRsp CreateUser(CreateUserReq req)
		{
			var rsp = new SingleRsp();

			var user = _rep.FindByEmail(req.Email);

			if (user != null)
			{
				rsp.Code = "422";
				rsp.SetError("User email was exists");
				return rsp;
			}

			user = new User();
			user.Email = req.Email;
			user.Name = req.Name;
			user.Password = req.Password;
			user.Token = UserSvc.RandomString(64);

			_rep.Create(user);

			rsp.Data = user;

			return rsp;
		}

		public SingleRsp RefreshUserToken(RefreshUserTokenReq req)
		{
			var rsp = new SingleRsp();

			var user = _rep.FindByEmail(req.Email);

			if (user == null)
			{
				rsp.Code = "404";
				rsp.SetError("User not found");
				return rsp;
			}

			if (user.Password != req.Password)
			{
				rsp.Code = "422";
				rsp.SetError("Password is invalid");
				return rsp;
			}

			user.Token = UserSvc.RandomString(64);

			_rep.Update(user);

			rsp.Data = user;

			return rsp;
		}

		public SingleRsp UpdateUserPassword(UpdateUserPasswordReq req)
		{
			var rsp = new SingleRsp();

			var user = _rep.FindByEmail(req.Email);

			if (user == null) 
			{
				rsp.Code = "404";
				rsp.SetError("User not found");
				return rsp;
			}

			if (user.Password != req.oldPassword) 
			{
				rsp.Code = "422";
				rsp.SetError("Old password is invalid");
				return rsp;
			}

			user.Password = req.newPassword;

			_rep.Update(user);

			rsp.Data = user;

			return rsp;
		}

		protected static string RandomString(int length)
		{
			Random random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}
	}
}
