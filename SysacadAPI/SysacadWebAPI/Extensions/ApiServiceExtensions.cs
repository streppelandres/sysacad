using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace SysacadWebAPI.Extensions
{
    public static class ApiServiceExtensions
    {
        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config => {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddSwaggerGen(config =>
            {
                config.EnableAnnotations();
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SysacadApi", Version = "v1",
                    Description = "API created for the Programming & Laboratory II exam",
                    Contact = new OpenApiContact
                    {
                        Name = "Andrés Caballero Streppel",
                        Url = new Uri("https://github.com/streppelandres")
                    }
                });
            });
        }
    }
}
