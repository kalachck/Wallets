namespace Wallets.Api.AppDependenciesConfiguration
{
    public static partial class AppDependenciesConfiguration
    {
        public static WebApplicationBuilder ConfigureDependencies(this WebApplicationBuilder builder)
        {
            builder.AddExternalDependencies()
                .AddServices()
                .AddOptions();

            return builder;
        }
    }
}
