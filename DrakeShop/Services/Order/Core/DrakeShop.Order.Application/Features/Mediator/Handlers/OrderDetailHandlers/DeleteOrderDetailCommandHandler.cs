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
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand>
    {
        private readonly IRepository<OrderDetail> _repository;

        public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(values);

        }
    }
}
