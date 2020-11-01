using Basket.Business.Abstract;
using Basket.Business.Dto.Request;
using Basket.Business.Dto.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemController : ControllerBase
    {
        private readonly IBasketItemService _basketItemService;

        public BasketItemController(IBasketItemService basketItemService)
        {
            _basketItemService = basketItemService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Sepete Ürün Ekleme İşlemi", Description = "Sepete Ürün Ekleme")]
        [ProducesResponseType(typeof(BasketAddResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] BasketItemAddRequestModel requestModel)
        {
            var result = _basketItemService.Add(requestModel);
            return Ok(result);
        }
    }
}
