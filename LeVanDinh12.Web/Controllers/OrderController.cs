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
    public class OrderController : ControllerBase
    {
        private OrderSvc OrderSvc;

        public OrderController()
        {
            OrderSvc = new OrderSvc();
        }

        [HttpGet("all")]
        public IActionResult GetOrders()
        {
            return Ok(OrderSvc.GetOrders());
        }

        [HttpGet("by-id/{id}")]
        public IActionResult GetOrdersById(int id)
        {
            return Ok(OrderSvc.GetOrdersById(id));
        }

        [HttpGet("get-flower-in-order/{id}")]
        public IActionResult GetFlowerInOrder(int id)
        {
            return Ok(OrderSvc.GetFlowerInOrder(id));
        }


        [HttpPost("create")]
        public IActionResult CreateOrder([FromBody] CreateOrderReq order)
        {
            var res = new SingleRsp();
            res = OrderSvc.CreateOrder(order);
            return Ok(res);
        }
    
        [HttpPut("update/{id}")]
        public IActionResult CreateOrder(int id, [FromBody] UpdateOrderReq orderReq)
        {
            var res = new SingleRsp();
            res = OrderSvc.UpdateOrder(id, orderReq);
            return Ok(res);
        }
        [HttpPatch("payment/{id}")]
        public IActionResult PaymentOrder(int id)
        {
            var res = new SingleRsp();
            res = OrderSvc.Payment(id);
            return Ok(res);
        }

        [HttpPatch("add-flower-to-order/{id}")]
        public IActionResult AddFlowerToOrder(int id, [FromBody] CreateFlowerOrderReq req)
        {
            var res = new SingleRsp();
            res = OrderSvc.addFLowerToOrder(id, req);
            return Ok(res);
        }

        [HttpPatch("remove-flower-from-order/{id}/{flowerId}")]
        public IActionResult AddFlowerToOrder(int id, int flowerId)
        {
            var res = new SingleRsp();
            res = OrderSvc.RemoveFlowerFromOrder(id, flowerId);
            return Ok(res);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            return Ok(OrderSvc.DeleteOrder(id));
        }
    }
}
