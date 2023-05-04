using Microsoft.EntityFrameworkCore;
using Wallets.DataAccess.Entities;

namespace Wallets.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        { }
    }
}
