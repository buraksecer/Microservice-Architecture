using Basket.Business.Dto.Request;
using Basket.Business.Dto.Response;
using System.Threading.Tasks;

namespace Basket.Business.Abstract
{
    public interface IBasketItemService
    {
        Task<BasketAddResponseModel> Add(BasketItemAddRequestModel requestModel);
    }
}
