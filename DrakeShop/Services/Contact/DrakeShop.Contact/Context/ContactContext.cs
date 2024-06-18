using DrakeShop.Contact.Models;
using Microsoft.EntityFrameworkCore;

namespace DrakeShop.Contact.Context
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}
