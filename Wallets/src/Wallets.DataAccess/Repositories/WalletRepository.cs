using Microsoft.EntityFrameworkCore;
using Wallets.DataAccess.Entities;
using Wallets.DataAccess.Repositories.Abstract;

namespace Wallets.DataAccess.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationContext _applicationContext;

        public WalletRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Wallet>> GetWalletsAsync()
        {
            return await _applicationContext.Wallets.AsNoTracking().ToListAsync();
        }
    }
}
