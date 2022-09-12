using System;
using System.Collections.Generic;

#nullable disable

namespace LeVanDinh12.DAL.Models
{
    public partial class Post
    {
        public Post()
        {
            CategoryPosts = new HashSet<CategoryPost>();
            PostComments = new HashSet<PostComment>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string MainImageUrl { get; set; }
       
        public long UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CategoryPost> CategoryPosts { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
    }
}
