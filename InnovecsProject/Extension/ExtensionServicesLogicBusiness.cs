using InnovecsProject.Business.Implements;
using InnovecsProject.Business.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extension
{
    public static class ExtensionServicesLogicBusiness
    {
        public static void ResolveDependencyServicesLogicalBusiness(this IServiceCollection services)
        {
            services.AddHttpClient<IBestDealServices, BestDealServices>();
            services.AddTransient<IBestDealServices, BestDealServices>();
            services.AddTransient<IDealServicesOne, DealServicesOne>();
            services.AddTransient<IDealServicesTwo, DealServicesTwo>();
            services.AddTransient<IDealServicesThree, DealServicesThree>();
        }
    }
}