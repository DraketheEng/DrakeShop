using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrakeShop.Order.Application.Features.Mediator.Commands.AddressCommands
{
    public class DeleteAddressCommand : IRequest
    {

        public int Id { get; set; }

        public DeleteAddressCommand(int id)
        {
            Id = id;
        }

    }
}
