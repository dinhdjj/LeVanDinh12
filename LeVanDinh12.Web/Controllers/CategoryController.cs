using LeVanDinh12.BLL;
using LeVanDinh12.Common.Req;
using LeVanDinh12.Common.Rsp;
using LeVanDinh12.DAL.Models;
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

        [HttpPost("create")]
        public IActionResult CreateCategory([FromBody] CreateCategoryReq req)
        {
            //if (string.IsNullOrEmpty(cate.Name) == true)
            //{
            //    ModelState.AddModelError("", "Name not null");
            //    return Ok(cate);
            //}
            //var res = new SingleRsp();
            //res.Data = categorySvc.Create(cate);
            //return Ok(res);

            return Ok(categorySvc.CreateCategory(req));
        }

        [HttpGet("get-id/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            return Ok(categorySvc.Read(id));
        }

        [HttpGet("all")]
        public IActionResult GetCategory()
        {
            return Ok(categorySvc.GetCategories());
        }

        [HttpPost("update")]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryReq req)
        {
            return Ok(categorySvc.UpdateCategory(req));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteCategoryById(int id)
        {
            return Ok(categorySvc.DeleteCategory(id));
        }
    }
}
