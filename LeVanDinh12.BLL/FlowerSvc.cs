using LeVanDinh12.Common.BLL;
using LeVanDinh12.Common.Rsp;
using LeVanDinh12.DAL;
using LeVanDinh12.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LeVanDinh12.Common.Req;

namespace LeVanDinh12.BLL
{
    public class FlowerSvc : GenericSvc<FlowerRep, Flower>
    {
        private FlowerRep flowerRep;
        public FlowerSvc()
        {
            flowerRep = new FlowerRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public override SingleRsp Delete(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.DeleteFlowerById(id);
            return res;
        }

        public SingleRsp GetFlowers()
        {
            var res = new SingleRsp();
            res.Data = _rep.All;
            return res;
        }

        public SingleRsp GetFlowersWithPage(int page, int size)
        {
            var res = new SingleRsp();
            var flowers = flowerRep.All;
            int offset = size * (page - 1);
            res.Data = flowers.Skip(offset).Take(size).ToList();
            return res;
        }

        public SingleRsp CreateFlower(CreateFlowerReq flowerReq)
        {
            var res = new SingleRsp();
            Flower flower = new Flower();
            flower.Name = flowerReq.Name;
            flower.Body = flowerReq.Body;
            flower.UnitPrice = flowerReq.UnitPrice;
            flower.Quantity = flowerReq.Quantity;
            flower.MainImageUrl = flowerReq.MainImageUrl;
            flower.UserId = flowerReq.UserId;
            _rep.CreateFlower(flower);
            res.Data = flower;

            return res;
        }

        public SingleRsp UpdateFlower(UpdateFlowerReq flowerReq)
        {
            var res = new SingleRsp();
            Flower flower = flowerRep.Read((int)flowerReq.Id);
            flower.Name = flowerReq.Name;
            flower.Body = flowerReq.Body;
            flower.UnitPrice = flowerReq.UnitPrice;
            flower.Quantity = flowerReq.Quantity;
            flower.MainImageUrl = flowerReq.MainImageUrl;
            _rep.UpdateFlower(flower);
            res.Data = flower;

            return res;
        }
    }
}
