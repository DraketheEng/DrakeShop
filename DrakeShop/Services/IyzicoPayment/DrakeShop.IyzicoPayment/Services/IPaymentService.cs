using DrakeShop.IyzicoPayment.Models;
using Iyzipay.Model;

namespace DrakeShop.IyzicoPayment.Services
{
    public interface IPaymentService
    {
        Task<ThreedsInitialize> InitializePayment();
        Task<CallbackData> HandlePaymentCallback(IFormCollection collections);
    }
}
