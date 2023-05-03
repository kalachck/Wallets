using Wallets.BusinessLogic.Services;
using Wallets.BusinessLogic.Services.Abstract;
using Wallets.DataAccess.Repositories;
using Wallets.DataAccess.Repositories.Abstract;

namespace Wallets.Api.AppDependenciesConfiguration
{
    public static partial class AppDependenciesConfiguration
    {
        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IWalletRepository, WalletRepository>();

            builder.Services.AddScoped<IWalletService, WalletService>();

            return builder;
        }
    }
}
