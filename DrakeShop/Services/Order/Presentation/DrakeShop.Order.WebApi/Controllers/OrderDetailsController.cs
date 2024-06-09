using DrakeShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using DrakeShop.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrakeShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {

            var values = await _mediator.Send(new GetOrderDetailQuery());

            return Ok(values);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {

            var values = await _mediator.Send(new GetOrderDetailByIdQuery(id));

            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {

            await _mediator.Send(command);

            return Ok("Sipariş Detayı Başarıyla Eklendi.");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {

            await _mediator.Send(new DeleteOrderDetailCommand(id));

            return Ok("Sipariş Detayı Başarıyla Silindi.");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {

            await _mediator.Send(command);

            return Ok("Sipariş Detayı Başarıyla Güncellendi.");

        }
    }
}
