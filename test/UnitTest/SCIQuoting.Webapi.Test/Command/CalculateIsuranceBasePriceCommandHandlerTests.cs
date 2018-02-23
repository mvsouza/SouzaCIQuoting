using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Ordering.Application
{
    using MediatR;
    using Moq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;
    using SCIQuoting.Webapi.Infrastructure.Repositories;
    using SCIQuoting.Webapi.Application.Commands;
    using SCIQuoting.Webapi.Application.Models;

    public class CalculateIsuranceBasePriceCommandHandlerTests
    {
        private readonly Mock<IIsuranceBasePriceRepository> _isurancePriceRepository;
        private readonly Mock<IMediator> _mediator;

        public CalculateIsuranceBasePriceCommandHandlerTests()
        {
            _isurancePriceRepository = new Mock<IIsuranceBasePriceRepository>();
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async void Calculate_Exact_Match()
        {
            //Given
            _isurancePriceRepository.Setup(r => r.GetAsync()).Returns(Task.FromResult(new IsuranceBasePrice(VehicleType.Motocycle, 2000, "Fit", "Honda", 1000)));
            var priceCommand = new CalculateIsuranceBasePrice(VehicleType.Motocycle, 2000, "Fit", "Honda");
            //When
            var handler = new CalculateIsuranceBasePriceCommandHandler(_mediator.Object,_isurancePriceRepository.Object);
            var cltToken = new System.Threading.CancellationToken();
            var result = handler.Handle(priceCommand, cltToken);
            //Then
            decimal expected = 1000;
            Assert.True(expected == await result);

        }

    }
}