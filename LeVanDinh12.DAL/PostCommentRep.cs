using LeVanDinh12.Common.DAL;
using LeVanDinh12.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeVanDinh12.DAL
{
    public class PostCommentRep : GenericRep<FlowerFlowerContext, PostComment>
    {
        #region -- Overrides --

        #endregion

        public override PostComment Read(int id)
        {
            return Context.PostComments.Find((long)id);
        }

        public void Delete(PostComment postComment)
        {
            Context.PostComments.Remove(postComment);
            Context.SaveChanges();
        }

        #region -- Methods --

        #endregion

        public IQueryable<PostComment> GetPostComments()
        {
            return Context.PostComments.Select(u => u);
        }

        public PostComment FindByContent(string content)
        {
            return Context.PostComments.Where(u => u.Content == content).FirstOrDefault();
        }

        public Post FindByBody(string body)
        {
            return Context.Posts.Where(u => u.Body == body).FirstOrDefault();
        }

        public Post FindByURL(string url)
        {
            return Context.Posts.Where(u => u.MainImageUrl == url).FirstOrDefault();
        }

        public User FindByEmail(string email)
        {
            return Context.Users.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}
