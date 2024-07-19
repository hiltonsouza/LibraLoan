using LibraLoan.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraLoan.Infrastructure.Persistence
{
    public class LibraLoanDbContext : DbContext
    {
        public LibraLoanDbContext(DbContextOptions<LibraLoanDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
