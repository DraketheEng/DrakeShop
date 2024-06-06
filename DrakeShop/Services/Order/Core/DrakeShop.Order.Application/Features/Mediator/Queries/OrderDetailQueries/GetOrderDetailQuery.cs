using DrakeShop.Order.Application.Features.Mediator.Results.OrderDetailResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrakeShop.Order.Application.Features.Mediator.Queries.OrderDetailQueries
{
    public class GetOrderDetailQuery : IRequest<List<GetOrderDetailQueryResult>>
    {
    }
}
