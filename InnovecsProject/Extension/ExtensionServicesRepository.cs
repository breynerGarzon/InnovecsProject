using InnovecsProject.Repository.Implements;
using InnovecsProject.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extension
{
    public static class ExtensionServicesRepository
    {
        public static void ResolveDependencyRepository(this IServiceCollection services)
        {
            services.AddTransient<IApiOneRepository, ApiOneRepository>();
            services.AddTransient<IApiTwoRepository, ApiTwoRepository>();
            services.AddTransient<IApiThreeRepository, ApiThreeRepository>();
        }
    }
}