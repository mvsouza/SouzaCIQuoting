using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SCIQuoting.Webapi.Controllers;
using SCIQuoting.Webapi.Infrastructure.EventBus.Abstractions;
using SCIQuoting.Webapi.Infrastructure.Repositories;
using SCIQuoting.Webapi.Application.Models;
using System;
using Xunit;

namespace SCIQuoting.Webapi.Test
{
    public class QuotingRequestControllerTest
    {
        private Mock<HttpContext> _contextHttpMock;
        private Mock<IEventBus> _eventBus;
        private Mock<IInsuranceQuotingRequestRepository> _repository;
        public QuotingRequestControllerTest(){
            _eventBus = new Mock<IEventBus>();
            _repository = new Mock<IInsuranceQuotingRequestRepository>();
            _contextHttpMock = new Mock<HttpContext>();
        }

        [Fact]
        public async void Return_New_Id()
        {
            var ctrl = new QuotingRequestController(_eventBus.Object, _repository.Object);
            ctrl.ControllerContext.HttpContext = _contextHttpMock.Object;
            var actionResult = await ctrl.Post(new QuoteRequestViewModel());
            var res = Assert.IsType<OkObjectResult>(actionResult);
            Assert.IsAssignableFrom<Guid>(res.Value);
        }
    }
}
