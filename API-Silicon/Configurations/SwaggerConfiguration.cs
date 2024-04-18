using Microsoft.OpenApi.Models;

namespace API_Silicon.Configurations;

// https://swagger.io/docs/specification/authentication/api-keys/
public static class SwaggerConfiguration
{
    public static void RegisterSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(x =>
        {
            x.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Description = "API Key Authorization",
                Name = "key",
                In = ParameterLocation.Query,
                Type = SecuritySchemeType.ApiKey
            });

            x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                         Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        }
                    }, new string[] {}
                }
            });
        });
    }
}
