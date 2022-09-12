using LeVanDinh12.Common.DAL;
using LeVanDinh12.Common.Req;
using LeVanDinh12.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace LeVanDinh12.DAL
{
    public class UserRep : GenericRep<FlowerFlowerContext, User>
    {
		#region -- Overrides --

		#endregion

		public override User Read(int id)
		{
			return Context.Users.Find((long)id);
		}

		#region -- Methods --

		#endregion

		public IQueryable<User> GetUsers()
        {
            return Context.Users.Select(u=>u);
        }

		public User FindByEmail(string email)
		{
			return Context.Users.Where(u => u.Email == email).FirstOrDefault();
		}

		public User FindByToken(string token)
        {
			return Context.Users.Where(u => u.Token == token).FirstOrDefault();
		}
    
		public void Delete(User user)
    {
			Context.Users.Remove(user);
			Context.SaveChanges();
    }
	}
}
