using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeVanDinh12.BLL;
using LeVanDinh12.Common.Req;
using LeVanDinh12.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeVanDinh12.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerCommentController : ControllerBase
    {
        private FlowerCommentSvc flowerCommentSvc;
        public FlowerCommentController()
        {
            flowerCommentSvc = new FlowerCommentSvc();
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetFlowerCommentById(int id)
        {
            return Ok(flowerCommentSvc.Read(id));
        }

        [HttpGet("list-by-flower-id/{flowerId}")]
        public IActionResult GetFlowerCommentsByFlowerId(int flowerId)
        {
            return Ok(flowerCommentSvc.GetFlowerCommentsByFlowerId(flowerId));
        }

        [HttpPost("create")]
        public IActionResult CreateFlowerComment([FromBody] CreateFlowerCommentReq flowerCommentReq)
        {
            var res = new SingleRsp();
            res = flowerCommentSvc.CreateFlowerComment(flowerCommentReq);
            return Ok(res);
        }

        [HttpPost("update")]
        public IActionResult UpdateFlower([FromBody] UpdateFlowerCommentReq flowerCommentReq)
        {
            var res = new SingleRsp();
            res = flowerCommentSvc.UpdateFlowerComment(flowerCommentReq);
            return Ok(res);
        }

        [HttpDelete("delete-by-id/{id}")]
        public IActionResult DeleteFlowerComment(int id)
        {
            return Ok(flowerCommentSvc.Delete(id));
        }
    }
}
