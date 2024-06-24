using Microsoft.OpenApi.Models;

namespace WebApi.Excetensions
{
    public static class SwaggerServiceExtentions
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Commerce API", Version = "v1" });

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer schema. Example:\"Authorization: Bearer {token}\"",
                    
                    Name = "Authorization",

                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "bearer"
                    }

                };
                c.AddSecurityDefinition("bearer",securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {securitySchema, new[] {"bearer"} }
                };
                c.AddSecurityRequirement(securityRequirement);

            });

            return services;
        }
    }
}
