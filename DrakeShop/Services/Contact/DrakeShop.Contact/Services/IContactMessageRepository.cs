using DrakeShop.Contact.Models;

namespace DrakeShop.Contact.Services
{
    public interface IContactMessageRepository
    {
        Task<IEnumerable<ContactMessage>> GetAllMessages();
        Task<ContactMessage> GetMessageById(int id);
        Task AddMessage(ContactMessage message);
        Task SaveChangesAsync();
    }
}
