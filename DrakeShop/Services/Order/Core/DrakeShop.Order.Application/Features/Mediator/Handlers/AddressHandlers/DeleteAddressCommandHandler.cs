using DrakeShop.Order.Application.Features.Mediator.Commands.AddressCommands;
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
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
    {

        private readonly IRepository<Address> _repository;

        public DeleteAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(values);

        }

    }
}
