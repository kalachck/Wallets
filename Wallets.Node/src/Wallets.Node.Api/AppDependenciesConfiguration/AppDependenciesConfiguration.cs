namespace Wallets.Node.Api.AppDependenciesConfiguration
{
    public static partial class AppDependenciesConfiguration
    {
        public static WebApplicationBuilder ConfigureDependencies(this WebApplicationBuilder builder)
        {
            builder.AddServices()
                .AddOptions();

            return builder;
        }
    }
}
