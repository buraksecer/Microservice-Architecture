using Basket.Business.Abstract;
using Basket.Business.Dto.Request;
using Basket.Business.Dto.Response;
using Basket.Core.Exceptions;
using Basket.Dal.Infrastructure;
using Basket.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Business.Concrete
{
    public class BasketItemService : IBasketItemService
    {
        private readonly IRepository<Entities.Models.BasketItem> _basketRepository;
        public ICollection<Product> SimileProducts { get; } = new HashSet<Product>
        {
            new Product{Id = 1,CategoryId = 10,ProductName = "Domates",StockQuantity = 2000 },
            new Product{Id=2,CategoryId = 11,ProductName="Marul",StockQuantity = 1}
        };

        public BasketItemService(IRepository<Entities.Models.BasketItem> basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<BasketAddResponseModel> Add(BasketItemAddRequestModel requestModel)
        {
            var product = new Product();
             
            var stock = (from p in SimileProducts.ToList() where p.Id == requestModel.BasketItem.ProductId select SimileProducts).Count();

            if (stock > 0)
            {
                var basketItemId = _basketRepository.Insert(requestModel.BasketItem);
                return new BasketAddResponseModel
                {
                    Id = basketItemId
                };
            }
            else
            {
                throw new NotFoundException("The product is out of stock ");
            }
        }
    }
}
