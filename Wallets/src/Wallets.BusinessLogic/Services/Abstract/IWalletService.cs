using Wallets.DataAccess.Entities;

namespace Wallets.BusinessLogic.Services.Abstract
{
    public interface IWalletService
    {
        Task<List<Wallet>> GetBalancesAsync();
    }
}
