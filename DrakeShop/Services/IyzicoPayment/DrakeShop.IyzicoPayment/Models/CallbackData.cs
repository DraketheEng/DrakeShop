namespace DrakeShop.IyzicoPayment.Models
{
    public sealed record CallbackData(
     string Status,
     string PaymentId,
     string ConversationData,
     string ConversationId,
     string MDStatus);
}
