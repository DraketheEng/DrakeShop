using DrakeShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using DrakeShop.Order.Application.Interfaces;
using DrakeShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrakeShop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand>
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {

            await _repository.CreateAsync(new OrderDetail
            {
                ProductAmount = request.ProductAmount,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductId = request.ProductId,
                ProductTotalPrice = request.ProductTotalPrice,
                OrderingId = request.OrderingId,
            });

        }
    }
}
