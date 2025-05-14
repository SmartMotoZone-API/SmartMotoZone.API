using Microsoft.OpenApi.Models;
namespace SmartMotoZone.API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddCustomizedSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Smart Moto Zone API",
                    Version = "v1",
                    Description = "API para gerenciamento de motos na zona inteligente",
                    Contact = new OpenApiContact
                    {
                        Name = "Equipe SmartMotoZone",
                        Email = "kaiocumpian30@gmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                ///var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                ///var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                ///options.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}