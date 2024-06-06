using DrakeShop.Order.Application.Features.Mediator.Results.AddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrakeShop.Order.Application.Features.Mediator.Queries.AddressQueries
{
    public class GetAddressQuery : IRequest<List<GetAddressQueryResult>>
    {

    }
}
