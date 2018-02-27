namespace SCIQuoting.Webapi.Application.Commands
{
    using MediatR;
    using SCIQuoting.Webapi.Application.Models;
    using SCIQuoting.Webapi.Infrastructure.Idempotency;
    using SCIQuoting.Webapi.Infrastructure.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;

    // Regular CommandHandler
    public class CalculateIsuranceBasePriceCommandHandler
        : IRequestHandler<CalculateIsuranceBasePrice, decimal>
    {
        private readonly IIsuranceBasePriceRepository _isurancePriceRepository;
        private readonly IMediator _mediator;
        private Task<IEnumerable<IsuranceBasePrice>> _gettingBasePrices;
        private IEnumerable<IsuranceBasePrice> _tableBasePrices;


        // Using DI to inject infrastructure persistence Repositories
        public CalculateIsuranceBasePriceCommandHandler(IMediator mediator, IIsuranceBasePriceRepository _isurancePriceRepository)
        {
            _isurancePriceRepository = _isurancePriceRepository ?? throw new ArgumentNullException(nameof(_isurancePriceRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _gettingBasePrices = _isurancePriceRepository.GetAsync();
        }
        
        public async Task<decimal> Handle(CalculateIsuranceBasePrice message, CancellationToken cancellationToken)
        {
            LoadTable();
            var match = PerfectMatch(message) ??
                        MakehMatch(message) ??
                        YearMatch(message) ??
                        VehicleMatch(message);
            return match?.Price ?? 1000;
        }


        private async void LoadTable() {
            if(_tableBasePrices == null)
                _tableBasePrices = await _gettingBasePrices;
        }

        private IsuranceBasePrice PerfectMatch(CalculateIsuranceBasePrice message)
        {
            return _tableBasePrices.FirstOrDefault(p => p.Make == message.Make &&
                                                        p.ManufacturingYear == message.ManufacturingYear &&
                                                        p.Model == message.Model &&
                                                        p.VehicleType == message.VehicleType);
        }
        private IsuranceBasePrice MakehMatch(CalculateIsuranceBasePrice message)
        {
            return _tableBasePrices.FirstOrDefault(p => p.Make == message.Make &&
                                                        p.ManufacturingYear == message.ManufacturingYear &&
                                                        p.VehicleType == message.VehicleType);
        }

        private IsuranceBasePrice YearMatch(CalculateIsuranceBasePrice message)
        {
            return _tableBasePrices.FirstOrDefault(p => p.ManufacturingYear == message.ManufacturingYear &&
                                                        p.VehicleType == message.VehicleType);
        }

        private IsuranceBasePrice VehicleMatch(CalculateIsuranceBasePrice message)
        {
            return _tableBasePrices.FirstOrDefault(p => p.VehicleType == message.VehicleType);
        }
    }


    // Use for Idempotency in Command process
    public class CalculateCarIsurancePriceBaseIdentifiedCommandHandler : IdentifiedCommandHandler<CalculateIsuranceBasePrice, decimal>
    {
        public CalculateCarIsurancePriceBaseIdentifiedCommandHandler(IMediator mediator, IRequestManager requestManager) : base(mediator, requestManager)
        {
        }

        protected override decimal CreateResultForDuplicateRequest()
        {
            return 0;                // Ignore duplicate requests for creating order.
        }
    }
}
