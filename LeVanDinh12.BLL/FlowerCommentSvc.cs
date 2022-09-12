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
    public class FlowerCommentSvc : GenericSvc<FlowerCommentRep, FlowerComment>
    {
        private FlowerCommentRep flowerCommentRep;
        public FlowerCommentSvc()
        {
            flowerCommentRep = new FlowerCommentRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public SingleRsp GetFlowerCommentsByFlowerId(int flowerId)
        {   
            var res = new SingleRsp();
            res.Data = _rep.GetFlowerCommentsByFlowerId(flowerId);
            return res;
        }

        public SingleRsp CreateFlowerComment(CreateFlowerCommentReq flowerCommentReq)
        {
            var res = new SingleRsp();
            FlowerComment flowerComment = new FlowerComment();
            flowerComment.Content = flowerCommentReq.Content;
            flowerComment.FlowerId = flowerCommentReq.FlowerId;
            flowerComment.AnonymousId = flowerCommentReq.AnonymousId;
            _rep.CreateFlowerComment(flowerComment);
            res.Data = flowerComment;

            return res;
        }

        public SingleRsp UpdateFlowerComment(UpdateFlowerCommentReq flowerCommentReq)
        {
            var res = new SingleRsp();
            FlowerComment flowerComment = flowerCommentRep.Read((int)flowerCommentReq.Id);
            flowerComment.Content = flowerCommentReq.Content;
            flowerComment.FlowerId = flowerCommentReq.FlowerId;
            flowerComment.AnonymousId = flowerCommentReq.AnonymousId;
            flowerCommentRep.UpdateFlowerComment(flowerComment);
            res.Data = flowerComment;

            return res;
        }

        public override SingleRsp Delete(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.DeleteFlowerCommentById(id);
            return res;
        }
    }
}
