using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LeVanDinh12.BLL;
using LeVanDinh12.Common.Req;
using LeVanDinh12.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LeVanDinh12.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AnonymouseController : ControllerBase
    {
        private readonly AnonymouseSvc AnonymouseSvc;

        public AnonymouseController()
        {
            AnonymouseSvc = new AnonymouseSvc();
        }

        [HttpGet("all")]
        public IActionResult GetAnonymouses()
        {
            return Ok(AnonymouseSvc.GetAnonymouses());
        }

        [HttpGet("by-id/{id}")]
        public IActionResult GetAnonymouseById(int id)
        {
            return Ok(AnonymouseSvc.Read(id));
        }

        [HttpGet("by-phone/{phone}")]
        public IActionResult GetAnonymouseById(string phone)
        {
            return Ok(AnonymouseSvc.ReadByPhone(phone));
        }

        [HttpPost("create")]
        public IActionResult CreateAnonymouse([FromBody] CreateAnonymouseReq req)
        {
            return Ok(AnonymouseSvc.CreateAnonymouse(req));
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateAnonymouse(int id, [FromBody] UpdateAnonymouseReq req)
        {
            return Ok(AnonymouseSvc.UpdateAnonymouse(id, req));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAnonymouse(int id)
        {
            return Ok(AnonymouseSvc.DeleteAnonymouse(id));
        }
    }
}
