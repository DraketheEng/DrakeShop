using DrakeShop.Contact.Context;
using DrakeShop.Contact.Models;
using Microsoft.EntityFrameworkCore;

namespace DrakeShop.Contact.Services
{
    public class ContactMessageRepository : IContactMessageRepository
    {
        private readonly ContactContext _context;

        public ContactMessageRepository(ContactContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactMessage>> GetAllMessages()
        {
            return await _context.ContactMessages.ToListAsync();
        }

        public async Task<ContactMessage> GetMessageById(int id)
        {
            return await _context.ContactMessages.FindAsync(id);
        }

        public async Task AddMessage(ContactMessage message)
        {
            await _context.ContactMessages.AddAsync(message);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
