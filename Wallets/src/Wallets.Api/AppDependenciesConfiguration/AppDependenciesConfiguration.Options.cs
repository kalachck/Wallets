using Wallets.BusinessLogic.Options;

namespace Wallets.Api.AppDependenciesConfiguration
{
    public static partial class AppDependenciesConfiguration
    {
        public static WebApplicationBuilder AddOptions(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<GrpcConnectionOptions>(
                builder.Configuration.GetSection(GrpcConnectionOptions.GrpcConnection));

            return builder;
        }
    }
}
