using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eShopTest.ApplicationService.ArticleAggregate.ViewModels;
using eShopTest.ApplicationService.BasketAggregate;
using eShopTest.ApplicationService.BasketAggregate.ViewModels;
using eShopTest.ApplicationService.SeedWork.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopTest.Presentation.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketApplicationService _basketApplicationService;

        public BasketController(IBasketApplicationService basketApplicationService)
        {
            _basketApplicationService = basketApplicationService;
        }

        [HttpPost("add-to-basket/{articleId:guid}/{basketId:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult AddToBasket([FromRoute]Guid articleId, [FromRoute]Guid? basketId = null)
        {
            _basketApplicationService.AddArticle(basketId, articleId);
            return Ok();
        }

        [HttpPost("add-to-basket/{articleId:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult AddToBasket([FromRoute]Guid articleId)
        {
            _basketApplicationService.AddArticle(null, articleId);
            return Ok();
        }

        [HttpPost("remove-of-basket/{basketId:guid}/{articleId:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult RemoveOfBasket(Guid basketId, Guid articleId)
        {
            _basketApplicationService.RemoveArticle(basketId, articleId);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PaginationViewModel<BasketViewModel>))]
        [ProducesResponseType(400)]
        public ActionResult GetAllBasketsPaginated(int size = 10, int page = 1)
        {
            return new OkObjectResult(_basketApplicationService.GetBaskts(size, page));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(200, Type = typeof(BasketViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult GetById(Guid id)
        {
            return new OkObjectResult(_basketApplicationService.Get(id));
        }
    }
}