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
    public class AnonymouseRep : GenericRep<FlowerFlowerContext, Anonymouse>
    {
		#region -- Overrides --

		#endregion

		public override Anonymouse Read(int id)
		{
			return Context.Anonymouses.Find((long)id);
		}

		#region -- Methods --

		#endregion

		public IQueryable<Anonymouse> GetAnonymouses()
        {
            return Context.Anonymouses.Select(u=>u);
        }

		public Anonymouse FindByPhone(string phone)
		{
			return Context.Anonymouses.Where(u => u.Phone == phone).FirstOrDefault();
		}

		public void Delete(Anonymouse anonymouse)
        {
			Context.Anonymouses.Remove(anonymouse);
			Context.SaveChanges();
        }
	}
}
