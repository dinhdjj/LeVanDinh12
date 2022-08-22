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
    public class UserController : ControllerBase
    {
        private readonly UserSvc UserSvc;

        public UserController()
        {
            UserSvc = new UserSvc();
        }

        [HttpGet("all")]
        public IActionResult GetUsers()
        {
            return Ok(UserSvc.GetUsers());
        }

        [HttpGet("by-id/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(UserSvc.Read(id));
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] CreateUserReq req)
        {
            return Ok(UserSvc.CreateUser(req));
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] RefreshUserTokenReq req) 
        {
            return Ok(UserSvc.RefreshUserToken(req));
        }

        [HttpPost("update-password")]
        public IActionResult UpdatePassword([FromBody] UpdateUserPasswordReq req)
        {
            return Ok(UserSvc.UpdateUserPassword(req));
        }
    }
}
