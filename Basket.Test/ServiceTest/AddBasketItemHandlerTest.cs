using AutoFixture;
using Basket.Business.Concrete;
using Basket.Core.Exceptions;
using Basket.Dal.Infrastructure;
using Basket.Entities.Models;
using Moq;
using System;
using Xunit;

namespace Basket.Test.ServiceTest
{
    public class AddBasketItemHandlerTest
    {
        #region field zone

        private readonly BasketItemService _sut;
        private readonly Fixture _fixture = new Fixture();
        private readonly Mock<IRepository<BasketItem>> _repository;

        #endregion

        public AddBasketItemHandlerTest()
        {
            _repository = new Mock<IRepository<BasketItem>>();
            _sut = new BasketItemService(_repository.Object);
        }

        [Fact]
        public void Insert_BasketItem_Should_Success()
        {
            //Arrange  

            //Act 
            var actual = _sut.Add(new Business.Dto.Request.BasketItemAddRequestModel
            {
                BasketItem = new BasketItem
                {
                    ProductId = 1
                }
            }).GetAwaiter().GetResult();

            //Assert
            Assert.Equal(0, actual.Id);
        }

        [Fact]
        public void Insert_BasketItem_Should_Exception()
        {
            //Arrange  

            //Act
            Action action = () =>
            {
                _sut.Add(new Business.Dto.Request.BasketItemAddRequestModel
                {
                    BasketItem = new BasketItem
                    {
                        Quantity = 1
                    }
                }).GetAwaiter().GetResult();
            };

            //Assert
            Assert.Throws<NotFoundException>(action);
        }
    }
}
