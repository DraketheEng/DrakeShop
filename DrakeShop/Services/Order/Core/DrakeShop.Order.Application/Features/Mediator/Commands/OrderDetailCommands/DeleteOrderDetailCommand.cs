using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrakeShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands
{
    public class DeleteOrderDetailCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteOrderDetailCommand(int id)
        {
            Id = id;
        }

    }
}
