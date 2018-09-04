using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using eShopTest.ApplicationService.ArticleAggregate;
using eShopTest.ApplicationService.ArticleAggregate.ViewModels;
using eShopTest.ApplicationService.SeedWork.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopTest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleApplicationService _articleApplicationService;

        public ArticlesController(IArticleApplicationService articleApplicationService)
        {
            _articleApplicationService = articleApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ArticleViewModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody]ArticleViewModel articleViewModel)
        {
            var articleCreated = _articleApplicationService.Create(articleViewModel);
            return CreatedAtAction(nameof(GetById),new { id = articleCreated.Id.ToString() }, articleCreated);
        }

        [HttpPatch("{id:guid}")]
        [ProducesResponseType(200, Type = typeof(ArticleViewModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult Patch([FromBody]ArticleViewModel articleViewModel, string id)
        {
            var articleEtidet = _articleApplicationService.Update(Guid.Parse(id), articleViewModel);
            return new OkObjectResult(articleEtidet);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PaginationViewModel<ArticleViewModel>))]
        [ProducesResponseType(400)]
        public ActionResult Get([FromQuery]string search = null, [FromQuery]int size = 10, [FromQuery]int page = 1)
        {
            return new OkObjectResult(_articleApplicationService.GetArticles(search, size, page));
        }

        [HttpGet("{id:guid}", Name = "GetById")]
        [ProducesResponseType(200, Type = typeof(ArticleViewModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetById([FromRoute]Guid id)
        {
            return new OkObjectResult(_articleApplicationService.Get(id));
        }
    }
}