using DrakeShop.IyzicoPayment.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;

namespace DrakeShop.IyzicoPayment.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly Options _options;

        public PaymentService()
        {
            _options = new Options
            {
                ApiKey = "sandbox-xsyUyOct9zm8LwyHYiDe7XEUrqAOhFyo",
                SecretKey = "sandbox-7M2ZpUsh58da9v38D8cQuvRG2TtdXlRQ",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };
        }

        public async Task<ThreedsInitialize> InitializePayment()
        {
            CreatePaymentRequest request = new()
            {
                Locale = Locale.TR.ToString(),
                ConversationId = Guid.NewGuid().ToString(),
                Price = "1",
                PaidPrice = "1.2",
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = "B67832",
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                CallbackUrl = "https://localhost:7078/api/IyzicoPayments/PayCallBack"
            };

            PaymentCard paymentCard = new()
            {
                CardHolderName = "John Doe",
                CardNumber = "5528790000000008",
                ExpireMonth = "12",
                ExpireYear = "2030",
                Cvc = "123",
                RegisterCard = 0
            };
            request.PaymentCard = paymentCard;

            Buyer buyer = new()
            {
                Id = "BY789",
                Name = "John",
                Surname = "Doe",
                GsmNumber = "+905350000000",
                Email = "email@email.com",
                IdentityNumber = "74300864791",
                LastLoginDate = "2015-10-05 12:43:35",
                RegistrationDate = "2013-04-21 15:12:09",
                RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                Ip = "85.34.78.112",
                City = "Istanbul",
                Country = "Turkey",
                ZipCode = "34732"
            };
            request.Buyer = buyer;

            Address shippingAddress = new()
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new()
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new()
            {
                new BasketItem
                {
                    Id = "BI101",
                    Name = "Binocular",
                    Category1 = "Collectibles",
                    Category2 = "Accessories",
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = "0.3"
                },
                new BasketItem
                {
                    Id = "BI102",
                    Name = "Game code",
                    Category1 = "Game",
                    Category2 = "Online Game Items",
                    ItemType = BasketItemType.VIRTUAL.ToString(),
                    Price = "0.5"
                },
                new BasketItem
                {
                    Id = "BI103",
                    Name = "Usb",
                    Category1 = "Electronics",
                    Category2 = "Usb / Cable",
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = "0.2"
                }
            };
            request.BasketItems = basketItems;

            return ThreedsInitialize.Create(request, _options);
        }

        public async Task<CallbackData> HandlePaymentCallback(IFormCollection collections)
        {
            return new CallbackData(
                Status: collections["status"],
                PaymentId: collections["paymentId"],
                ConversationData: collections["conversationData"],
                ConversationId: collections["conversationId"],
                MDStatus: collections["mdStatus"]
            );
        }

    }
}
