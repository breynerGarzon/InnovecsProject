using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace InnovecsProject.Extension
{
    public static class ExtensionSwagger
    {
        public static void ResolveSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Innovecs Test",
                        Description = "Technical  Test"
                    });
                });
        }
    }
}