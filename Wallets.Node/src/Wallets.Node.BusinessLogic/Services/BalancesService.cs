using Grpc.Core;
using Microsoft.Extensions.Options;
using Nethereum.Web3;
using Org.BouncyCastle.Crypto.Tls;
using System.Net.WebSockets;
using Wallets.Node.BusinessLogic.Options;

namespace Wallets.Node.BusinessLogic.Services
{
    public class BalancesService : GetBalances.GetBalancesBase
    {
        private readonly SocketOptions _options;

        public BalancesService(IOptions<SocketOptions> options)
        {
            _options = options.Value;
        }

        public override async Task<WalletResponse> Get(IAsyncStreamReader<WalletRequest> requestStream, ServerCallContext context)
        {
            var addresses = new List<string>();

            while (await requestStream.MoveNext())
            {
                var requestItem = requestStream.Current;

                addresses.Add(requestItem.Address.ToString());
            }

            var balances = await GetBalancesThroughWebSocketAsync(addresses);

            return new WalletResponse() { Balances = { balances } };
        }

        private async Task<List<string>> GetBalancesThroughWebSocketAsync(List<string> addresses)
        {
            var balances = new List<string>();

            var web3 = new Web3(_options.AlchemyWebSocketUrl);

            using (var client = new ClientWebSocket())
            {
                await client.ConnectAsync(new Uri(_options.AlchemyWebSocketUrl), default);

                foreach (var address in addresses)
                {
                    var balance = await web3.Eth.GetBalance.SendRequestAsync(address);

                    balances.Add(Web3.Convert.FromWei(balance).ToString());
                }
            }

            return await Task.FromResult(balances);
        }
    }
}
