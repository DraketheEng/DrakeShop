using DrakeShop.IyzicoPayment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrakeShop.IyzicoPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IyzicoPaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public IyzicoPaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> Pay()
        {
            var threedsInitialize = await _paymentService.InitializePayment();
            return Ok(new { Content = threedsInitialize.HtmlContent, ConversationId = threedsInitialize.ConversationId });
        }

        [HttpPost]
        public async Task<IActionResult> PayCallBack([FromForm] IFormCollection collections)
        {
            var data = await _paymentService.HandlePaymentCallback(collections);
            if (data.Status != "success")
            {
                return BadRequest("Ödeme başarısız oldu!");
            }

            return Ok();
        }
    }
}
