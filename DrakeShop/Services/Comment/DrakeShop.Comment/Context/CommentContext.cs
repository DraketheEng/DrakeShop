using DrakeShop.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakeShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog=DrakeShopCommentDb;User=sa;Password=15937557350Aa;TrustServerCertificate=True;");
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
