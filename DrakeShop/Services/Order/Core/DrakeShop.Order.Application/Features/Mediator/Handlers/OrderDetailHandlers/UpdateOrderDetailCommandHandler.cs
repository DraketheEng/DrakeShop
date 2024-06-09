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
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
    {

        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.OrderDetailId);

            values.ProductName = request.ProductName;
            values.ProductPrice = request.ProductPrice;
            values.ProductTotalPrice = request.ProductTotalPrice;
            values.ProductAmount = request.ProductAmount;
            values.OrderDetailId = request.OrderDetailId;
            values.OrderingId = request.OrderingId;

            await _repository.UpdateAsync(values);

        }
    }
}
