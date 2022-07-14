using InnovecsProject.Business.BusinessLogic.ApiOne.Implements;
using InnovecsProject.Business.BusinessLogic.ApiOne.Interface;
using InnovecsProject.Business.BusinessLogic.ApiThree.Implements;
using InnovecsProject.Business.BusinessLogic.ApiThree.Interface;
using InnovecsProject.Business.BusinessLogic.ApiTwo.Implements;
using InnovecsProject.Business.BusinessLogic.ApiTwo.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace InnovecsProject.Extension
{
    public static class ExtensionLogicBusiness
    {
        public static void ResolveDependencyLogicalBusiness(this IServiceCollection services)
        {
            services.AddTransient<IApiOneBusinessLogic, ApiOneBusinessLogic>();
            services.AddTransient<IApiTwoBusinessLogic, ApiTwoBusinessLogic>();
            services.AddTransient<IApiThreeBusinessLogic, ApiThreeBusinessLogic>();
        }
    }
}