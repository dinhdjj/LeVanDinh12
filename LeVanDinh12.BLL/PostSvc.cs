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
    public class PostSvc: GenericSvc<PostRep, Post>
    {
        private UserRep userRep;
        private PostRep postRep;
        private CategoryPostRep categoryPostRep;
        public PostSvc()
        {
            postRep = new PostRep();
            userRep = new UserRep();
            categoryPostRep = new CategoryPostRep();
        }

        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var rsq = new SingleRsp();

            rsq.Data = _rep.Read(id);
            return rsq;
        }

        public override SingleRsp Update(Post m)
        {
            var res = new SingleRsp();
            var u = m.Id > 0 ? _rep.Read((int)m.Id) : _rep.Read(m.Title);
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

        #region -- Methods --



        #endregion

        public SingleRsp GetPosts()
        {
            var rsp = new SingleRsp();

            rsp.Data = _rep.GetPosts();

            return rsp;
        }

        public SingleRsp CreatePost(CreatePostReq req)
        {
            var rsp = new SingleRsp();
            var post = _rep.FindByTitle(req.Title);

            var user = userRep.FindByToken(req.UserToken);

            if(user==null)
            {
                rsp.Code = "401";
                rsp.SetError("Unauthenticated!");
                return rsp;
            }

            post = new Post();
            post.Title = req.Title;
            post.Body = req.Body;
            post.MainImageUrl = req.MainImageURL;
            post.UserId = user.Id;
           
            _rep.Create(post);


            foreach (var categoryID in req.CategoryIds)
            {
                var categoryPost = new CategoryPost();
                categoryPost.PostId = post.Id;
                categoryPost.CategoryId = categoryID;
                categoryPostRep.Create(categoryPost);
            }

            rsp.Data = post;

            return rsp;
        }

        public SingleRsp UpdatePost(UpdatePostReq req)
        {
            var rsp = new SingleRsp();
            var u = _rep.FindByTitle(req.oldTitle);
            if (u == null)
            {
                rsp.Code = "422";
                rsp.SetError("Post name is exsits");
                return rsp;
            }

            if (u.Title != req.oldTitle)
            {
                rsp.Code = "422";
                rsp.SetError("Old title is invalid");
                return rsp;
            }
            var c = _rep.FindByBody(req.oldBody);
            if (c == null)
            {
                rsp.Code = "422";
                rsp.SetError("Post body is exsits");
                return rsp;
            }

            if (c.Body != req.oldBody)
            {
                rsp.Code = "422";
                rsp.SetError("Old body is invalid");
                return rsp;
            }
            var e = _rep.FindByURL(req.oldMainImageURL);
            if (e == null)
            {
                rsp.Code = "422";
                rsp.SetError("Post name is exsits");
                return rsp;
            }

            if (e.MainImageUrl != req.oldMainImageURL)
            {
                rsp.Code = "422";
                rsp.SetError("Old title is invalid");
                return rsp;
            }

            u.Title = req.newTitle;
            c.Body = req.newBody;
            e.MainImageUrl = req.newMainImageURL;
            _rep.Update(u);

            return rsp;
        }

        public SingleRsp DeletePost(int id)
        {
            var rsp = new SingleRsp();

            var post = _rep.Read(id);

            if (post == null)
            {
                rsp.Code = "404";
                rsp.SetError("Post not found");
                return rsp;
            }

            _rep.Delete(post);

            rsp.Data = post;

            return rsp;


        }
    }
}
