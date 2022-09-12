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
    public class PostCommentSvc: GenericSvc<PostCommentRep, PostComment>
    {
        private PostCommentRep postCommentRep;
        public PostCommentSvc()
        {
            postCommentRep = new PostCommentRep();
        }

        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var rsq = new SingleRsp();

            rsq.Data = _rep.Read(id);
            return rsq;
        }

        public override SingleRsp Update(PostComment m)
        {
            var res = new SingleRsp();
            var u = m.Id > 0 ? _rep.Read((int)m.Id) : _rep.Read(m.Content);
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

        public SingleRsp GetPostComments()
        {
            var rsp = new SingleRsp();

            rsp.Data = _rep.GetPostComments();

            return rsp;
        }

        public SingleRsp CreatePostComment(CreatePostCommentReq req)
        {
            var rsp = new SingleRsp();
            var postComment = _rep.FindByContent(req.Content);


            postComment = new PostComment();
            postComment.Content = req.Content;
            postComment.PostId = req.PostID;
            postComment.AnonymousId = req.AnonymousID;

            _rep.Create(postComment);
            rsp.Data = postComment;

            return rsp;
        }

        public SingleRsp UpdatePostComment(UpdatePostCommentReq req)
        {
            var rsp = new SingleRsp();
            var u = _rep.FindByContent(req.oldContent);
            if (u == null)
            {
                rsp.Code = "422";
                rsp.SetError("Post name is exsits");
                return rsp;
            }

            if (u.Content != req.oldContent)
            {
                rsp.Code = "422";
                rsp.SetError("Old content is invalid");
                return rsp;
            }
         
            u.Content = req.newContent;
           
            _rep.Update(u);

            return rsp;
        }
        public SingleRsp DeletePostComment(int id)
        {
            var rsp = new SingleRsp();

            var postComment = _rep.Read(id);

            if (postComment == null)
            {
                rsp.Code = "404";
                rsp.SetError("PostComment not found");
                return rsp;
            }

            _rep.Delete(postComment);

            rsp.Data = postComment;

            return rsp;


        }
    }
}
