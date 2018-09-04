using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopTest.ApplicationService.OrderAggregate;
using eShopTest.ApplicationService.OrderAggregate.ViewModels;
using eShopTest.ApplicationService.SeedWork.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopTest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderApplicationService _orderApplicationService;

        public OrdersController(IOrderApplicationService orderApplicationService) => _orderApplicationService = orderApplicationService;

        [HttpPost("{basketId:guid}")]
        [ProducesResponseType(201, Type = typeof(OrderViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Post(Guid basketId)
        {
            var order = _orderApplicationService.Create(basketId);
            return CreatedAtAction(nameof(GetById), new { id = order.Id.ToString() }, order);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PaginationViewModel<OrderViewModel>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult GetOrders(int pageSize = 10, int pageIndex = 1)
        {
            return new OkObjectResult(_orderApplicationService.GetOrders(pageSize, pageIndex));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(200, Type = typeof(OrderViewModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetById(Guid id)
        {
            return new OkObjectResult(_orderApplicationService.Get(id));
        }
    }
}