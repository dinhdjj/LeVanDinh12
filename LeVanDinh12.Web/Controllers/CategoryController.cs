using LeVanDinh12.BLL;
using LeVanDinh12.Common.Req;
using LeVanDinh12.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeVanDinh12.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategorySvc categorySvc;
        public CategoryController()
        {
            categorySvc = new CategorySvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult GetCategoryById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = categorySvc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult GetAllCategories()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }
    }
}
