using Microsoft.EntityFrameworkCore;
using Wallets.DataAccess;

namespace Wallets.Api.AppDependenciesConfiguration
{
    public static partial class AppDependenciesConfiguration
    {
        public static WebApplicationBuilder AddExternalDependencies(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("WalletsConnection");

            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return builder;
        }
    }
}
