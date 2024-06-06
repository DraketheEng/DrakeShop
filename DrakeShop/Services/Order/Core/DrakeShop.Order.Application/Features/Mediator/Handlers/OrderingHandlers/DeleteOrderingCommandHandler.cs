using DrakeShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
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
    public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
    {

        private readonly IRepository<Ordering> _repository;

        public DeleteOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(values);

        }
    }
}
