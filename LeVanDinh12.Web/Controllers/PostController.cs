using LeVanDinh12.BLL;
using LeVanDinh12.Common.Req;
using LeVanDinh12.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LeVanDinh12.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private PostSvc postSvc;
        public PostController()
        {
            postSvc = new PostSvc();
        }

        [HttpGet("all")]
        public IActionResult GetPosts()
        {
            return Ok(postSvc.GetPosts());
        }


        [HttpGet("by-id/{id}")]
        public IActionResult GetPostById(int id)
        {
            return Ok(postSvc.Read(id));
        }
        [HttpPost("create")]
        public IActionResult CreatePost([FromBody] CreatePostReq req)
        {
            return Ok(postSvc.CreatePost(req));
        }


        [HttpPut("update")]
        public IActionResult UpdatePost([FromBody] UpdatePostReq req)
        {
            return Ok(postSvc.UpdatePost(req));
        }

        [HttpDelete("delete-by-id/{id}")]
        public IActionResult DeletePost(int id)
        {
            return Ok(postSvc.DeletePost(id));
        }
    }
}
