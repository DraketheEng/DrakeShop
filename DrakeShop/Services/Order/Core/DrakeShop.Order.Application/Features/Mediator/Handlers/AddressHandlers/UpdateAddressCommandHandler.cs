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
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {

        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            
            var values = await _repository.GetByIdAsync(request.AddressId);

            values.City = request.City;
            values.District = request.District;
            values.Detail = request.Detail;
            values.UserId = request.UserId;

            await _repository.UpdateAsync(values);
        }
    }
}
