using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using Nethereum.Web3;
using Wallets.BusinessLogic.Options;
using Wallets.BusinessLogic.Services.Abstract;
using Wallets.DataAccess.Entities;
using Wallets.DataAccess.Repositories.Abstract;

namespace Wallets.BusinessLogic.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly GrpcConnectionOptions _options;

        public WalletService(IWalletRepository walletRepository,
            IOptions<GrpcConnectionOptions> options)
        {
            _walletRepository = walletRepository;
            _options = options.Value;
        }

        public async Task<List<Wallet>> GetBalancesAsync()
        {
            var wallets = await _walletRepository.GetWalletsAsync();

            var channel = GrpcChannel.ForAddress(_options.NodeUrl);
            var client = new GetBalances.GetBalancesClient(channel);

            using (var call = client.Get())
            {
                foreach (var wallet in wallets)
                {
                    await call.RequestStream.WriteAsync(new WalletRequest() { Address = wallet.Address });
                }

                await call.RequestStream.CompleteAsync();

                var response = await call.ResponseAsync;

                wallets.Zip(response.Balances, (x1, x2) => new { First = x1, Second = x2 })
                    .ToList()
                    .ForEach(pair => pair.First.Balance = pair.Second);
            }

            wallets.Sort((a, b) => b.Balance.CompareTo(a.Balance));

            return await Task.FromResult(wallets);
        }
    }
}
