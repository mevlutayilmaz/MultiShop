using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Contexts
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions options) : base(options) {}

        public DbSet<UserComment> UserComments { get; set; }
    }
}
