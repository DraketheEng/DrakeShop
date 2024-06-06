using DrakeShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using DrakeShop.Order.Application.Features.Mediator.Results.OrderingResults;
using DrakeShop.Order.Application.Interfaces;
using DrakeShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrakeShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryByIdHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {

        private readonly IRepository<Ordering> _repository;

        public GetOrderingQueryByIdHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            return new GetOrderingByIdQueryResult
            {
                OrderDate = values.OrderDate,
                OrderingId = values.OrderingId,
                TotalPrice = values.TotalPrice,
                UserId = values.UserId,
            };
        }
    }
}
