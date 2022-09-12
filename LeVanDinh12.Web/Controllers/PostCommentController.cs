using LeVanDinh12.BLL;
using LeVanDinh12.Common.Req;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeVanDinh12.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCommentController : ControllerBase
    {
        private PostCommentSvc postCommentSvc;
        public PostCommentController()
        {
            postCommentSvc = new PostCommentSvc();
        }

        [HttpGet("all")]
        public IActionResult GetPosComments()
        {
            return Ok(postCommentSvc.GetPostComments());
        }


        [HttpGet("by-id/{id}")]
        public IActionResult GetPostCommentById(int id)
        {
            return Ok(postCommentSvc.Read(id));
        }
        [HttpPost("create")]
        public IActionResult CreatePostComment([FromBody] CreatePostCommentReq req)
        {
            return Ok(postCommentSvc.CreatePostComment(req));
        }


        [HttpPut("update")]
        public IActionResult UpdatePostComment([FromBody] UpdatePostCommentReq req)
        {
            return Ok(postCommentSvc.UpdatePostComment(req));
        }

        [HttpDelete("delete-by-id/{id}")]
        public IActionResult DeletePostComment(int id)
        {
            return Ok(postCommentSvc.DeletePostComment(id));
        }
    }
}
