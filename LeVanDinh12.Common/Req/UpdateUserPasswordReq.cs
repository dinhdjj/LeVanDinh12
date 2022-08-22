using System;
using System.Collections.Generic;
using System.Text;

namespace LeVanDinh12.Common.Req
{
	public class UpdateUserPasswordReq
	{
		public string Email { get; set; }
		public string oldPassword { get; set; }
		public string newPassword { get; set; }
	}
}
