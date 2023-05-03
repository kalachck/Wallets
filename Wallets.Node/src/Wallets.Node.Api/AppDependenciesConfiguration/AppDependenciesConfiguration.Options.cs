using Wallets.Node.BusinessLogic.Options;

namespace Wallets.Node.Api.AppDependenciesConfiguration
{
    public static partial class AppDependenciesConfiguration
    {
        public static WebApplicationBuilder AddOptions(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<SocketOptions>(
                builder.Configuration.GetSection(SocketOptions.WebSocketUrls));

            return builder;
        }
    }
}
