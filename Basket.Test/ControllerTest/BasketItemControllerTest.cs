using AutoFixture;
using Basket.Api.Controllers;
using Basket.Business.Abstract;
using Basket.Business.Dto.Request;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Basket.Test.ControllerTest
{
    public class BasketItemControllerTest
    {
        #region field zone

        BasketItemController _sut;
        Mock<IBasketItemService> _basketService = new Mock<IBasketItemService>();
        BasketItemAddRequestModel _basketItemAddRequest;
        private readonly Fixture _fixture = new Fixture();

        #endregion

        public BasketItemControllerTest()
        {
            _basketItemAddRequest = _fixture.Create<BasketItemAddRequestModel>();
            _sut = new BasketItemController(_basketService.Object);
        }
         
        [Fact]
        public void Post_Should_Return_As_Expected()
        {
            //Arrage
            _basketService.Setup(c => c.Add(_basketItemAddRequest));

            //Act
            var actual = _sut.Add(_basketItemAddRequest).GetAwaiter().GetResult();

            //Assert
            Assert.IsAssignableFrom<IActionResult>(actual);
        } 
    }
}
