using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeVanDinh12.BLL;
using LeVanDinh12.Common.Req;
using LeVanDinh12.Common.Rsp;
using LeVanDinh12.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeVanDinh12.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private FlowerSvc flowerSvc;

        public FlowerController()
        {
            flowerSvc = new FlowerSvc();
        }

        [HttpGet("all")]
        public IActionResult GetFlowers()
        {
            return Ok(flowerSvc.GetFlowers());
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetFlowerById(int id)
        {
            return Ok(flowerSvc.Read(id));
        }

        [HttpGet("get-flowers/{page}/{size}")]
        public IActionResult GetFlowersByIdWithPage(int page, int size)
        {
            return Ok(flowerSvc.GetFlowersWithPage(page, size));
        }

        [HttpPost("create")]
        public IActionResult CreateFlower([FromBody] CreateFlowerReq flowerReq)
        {
            var res = new SingleRsp();
            res = flowerSvc.CreateFlower(flowerReq);
            return Ok(res);
        }

        [HttpPost("update")]
        public IActionResult UpdateFlower([FromBody] UpdateFlowerReq flowerReq)
        {
            var res = new SingleRsp();
            res = flowerSvc.UpdateFlower(flowerReq);
            return Ok(res);
        }

        [HttpDelete("delete-by-id/{id}")]
        public IActionResult DeleteFlower(int id)
        {
            return Ok(flowerSvc.Delete(id));
        }
    }
}
