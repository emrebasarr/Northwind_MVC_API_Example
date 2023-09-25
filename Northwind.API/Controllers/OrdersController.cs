using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.BLL.Repositories;
using Northwind.BLL.Services;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository) 
        {
            _orderRepository = orderRepository;
        }


        [HttpGet]
        [Route("listorders")]
        public IActionResult ListOrders()
        {
            var orders = _orderRepository.GetOrders();
            return Ok(orders);
        }
    }
}