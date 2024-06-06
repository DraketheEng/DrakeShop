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
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand>
    {

        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Address
            {
                UserId = request.UserId,
                District = request.District,
                City = request.City,
                Detail = request.Detail
            });
        }

    }
}
