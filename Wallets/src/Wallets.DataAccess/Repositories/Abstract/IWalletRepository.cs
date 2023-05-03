using Wallets.DataAccess.Entities;

namespace Wallets.DataAccess.Repositories.Abstract
{
    public interface IWalletRepository
    {
        Task<List<Wallet>> GetWalletsAsync();
    }
}
