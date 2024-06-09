using DrakeShop.Order.Application.Features.Mediator.Queries.AddressQueries;
using DrakeShop.Order.Application.Features.Mediator.Results.AddressResults;
using DrakeShop.Order.Application.Features.Mediator.Results.OrderingResults;
using DrakeShop.Order.Application.Interfaces;
using DrakeShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrakeShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, GetAddressByIdQueryResult>
    {

        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.Id);

            return new GetAddressByIdQueryResult
            {
                UserId = values.UserId,
                City = values.City,
                District = values.District,
                Detail = values.Detail,
                AddressId = values.AddressId,
            };

        }
    }
}
