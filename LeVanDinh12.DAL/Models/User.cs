using System;
using System.Collections.Generic;

#nullable disable

namespace LeVanDinh12.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Flowers = new HashSet<Flower>();
            Posts = new HashSet<Post>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Flower> Flowers { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
