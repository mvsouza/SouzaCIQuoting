namespace SCIQuoting.Webapi.Application.Commands
{
    using MediatR;
    using SCIQuoting.Webapi.Infrastructure.Idempotency;
    using SCIQuoting.Webapi.Infrastructure.Repositories;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    // Regular CommandHandler
    public class CalculateIsuranceBasePriceCommandHandler
        : IRequestHandler<CalculateIsuranceBasePrice, decimal>
    {
        private readonly IIsuranceBasePriceRepository _isurancePriceRepository;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public CalculateIsuranceBasePriceCommandHandler(IMediator mediator, IIsuranceBasePriceRepository _isurancePriceRepository)
        {
            _isurancePriceRepository = _isurancePriceRepository ?? throw new ArgumentNullException(nameof(_isurancePriceRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<decimal> Handle(CalculateIsuranceBasePrice message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
