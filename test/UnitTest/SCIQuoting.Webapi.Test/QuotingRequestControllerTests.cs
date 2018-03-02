using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SCIQuoting.Webapi.Controllers;
using SCIQuoting.Webapi.Infrastructure.EventBus.Abstractions;
using SCIQuoting.Webapi.Infrastructure.Repositories;
using SCIQuoting.Webapi.Application.Models;
using System;
using Xunit;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace SCIQuoting.Webapi.Test
{
    public class CacheEntryMock : ICacheEntry
    {
        public object Key => new object();

        public object Value { get; set; }
        public DateTimeOffset? AbsoluteExpiration { get; set; }
        public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }
        public IList<IChangeToken> ExpirationTokens => throw new NotImplementedException();

        public IList<PostEvictionCallbackRegistration> PostEvictionCallbacks => throw new NotImplementedException();

        public CacheItemPriority Priority { get; set; }
        public long? Size { get; set; }

        public void Dispose()
        {

        }
    }
    public class QuotingRequestControllerTest
    {
        private Mock<HttpContext> _contextHttpMock;
        private Mock<IEventBus> _eventBus;
        private Mock<IInsuranceQuotingRequestRepository> _repository;
        private Mock<IMemoryCache> _memoryCache;
        public QuotingRequestControllerTest()
        {
            _eventBus = new Mock<IEventBus>();
            _repository = new Mock<IInsuranceQuotingRequestRepository>();
            _contextHttpMock = new Mock<HttpContext>();
            _memoryCache = new Mock<IMemoryCache>();
        }
        [Fact]
        public async void Return_New_Id()
        {
            var ctrl = new QuotingRequestController(_eventBus.Object, _repository.Object, _memoryCache.Object);
            ctrl.ControllerContext.HttpContext = _contextHttpMock.Object;
            _memoryCache.Setup(m => m.CreateEntry(It.IsAny<Guid>()))
                        .Returns(new CacheEntryMock());
            var actionResult = await ctrl.Post(new QuoteRequestViewModel());
            var res = Assert.IsType<OkObjectResult>(actionResult);
            //_memoryCache.Verify(m => m.Set<InsuranceQuotingRequest>(It.IsAny<Guid>(), It.IsAny<InsuranceQuotingRequest>()));
            Assert.IsAssignableFrom<Guid>(res.Value);
        }
    }
}
