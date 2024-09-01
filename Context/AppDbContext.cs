using LunchStack.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LunchStack.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<UserWorkgroup> UserWorkgroups { get; set; }
        public DbSet<Workgroup> Workgroups { get; set; }

    }
}