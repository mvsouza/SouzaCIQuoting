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
            
            _isurancePriceRepository.Setup(r => r.GetAsync()).Returns(
                Task.FromResult(
                    (IEnumerable<IsuranceBasePrice>)new List<IsuranceBasePrice>(){
                        new IsuranceBasePrice(VehicleType.Car, 2001, "Fit", "Honda", 1345),
                        new IsuranceBasePrice(VehicleType.Motocycle, 2002, "Bis", "Honda", 1001),
                        new IsuranceBasePrice(VehicleType.Car, 2003, "Corsa", "Chev", 1034),
                        new IsuranceBasePrice(VehicleType.Car, 2004, "Uno", "Fiat", 1004),
                        new IsuranceBasePrice(VehicleType.Car, 2005, "Palio", "Fiat", 1245)
                    }
                )
            );
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async void Roungh_Type_Of_Vehicle()
        {
            //Given
            var priceCommand = new CalculateIsuranceBasePrice(VehicleType.Motocycle, 2000, "Fit", "Honda");
            //When
            var handler = new CalculateIsuranceBasePriceCommandHandler(_mediator.Object, _isurancePriceRepository.Object);
            var cltToken = new System.Threading.CancellationToken();
            var result = handler.Handle(priceCommand, cltToken);
            //Then
            decimal expected = 1001;
            Assert.True(expected == await result);

        }

        [Fact]
        public async void Calculate_Exact_Match()
        {
            //Given
            var priceCommand = new CalculateIsuranceBasePrice(VehicleType.Car, 2001, "Fit", "Honda");
            //When
            var handler = new CalculateIsuranceBasePriceCommandHandler(_mediator.Object,_isurancePriceRepository.Object);
            var cltToken = new System.Threading.CancellationToken();
            var result = handler.Handle(priceCommand, cltToken);
            //Then
            decimal expected = 1345;
            Assert.True(expected == await result);

        }
        [Fact]
        public async void Calculate_Same_Make()
        {
            //Given
            var priceCommand = new CalculateIsuranceBasePrice(VehicleType.Car, 2001, "Corola", "Honda");
            //When
            var handler = new CalculateIsuranceBasePriceCommandHandler(_mediator.Object, _isurancePriceRepository.Object);
            var cltToken = new System.Threading.CancellationToken();
            var result = handler.Handle(priceCommand, cltToken);
            //Then
            decimal expected = 1345;
            Assert.True(expected == await result);

        }
        [Fact]
        public async void Calculate_Same_Year()
        {
            //Given
            var priceCommand = new CalculateIsuranceBasePrice(VehicleType.Car, 2005, "Troller", "Geep");
            //When
            var handler = new CalculateIsuranceBasePriceCommandHandler(_mediator.Object, _isurancePriceRepository.Object);
            var cltToken = new System.Threading.CancellationToken();
            var result = handler.Handle(priceCommand, cltToken);
            //Then
            decimal expected = 1245;
            Assert.True(expected == await result);

        }
        [Fact]
        public async void Calculate_Same_Vehicle()
        {
            //Given
            var priceCommand = new CalculateIsuranceBasePrice(VehicleType.Motocycle, 2005, "Troller", "Geep");
            //When
            var handler = new CalculateIsuranceBasePriceCommandHandler(_mediator.Object, _isurancePriceRepository.Object);
            var cltToken = new System.Threading.CancellationToken();
            var result = handler.Handle(priceCommand, cltToken);
            //Then
            decimal expected = 1001;
            Assert.True(expected == await result);

        }

    }
}