using Core.Context;
using Core.Entites;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text; 

public static class IdentityServiceExtension
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
       
        var builder = services.AddIdentityCore<Users>(options =>
        {
            
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
        })
        .AddEntityFrameworkStores<JungleJumboreeDbContext>()
        .AddDefaultTokenProviders(); 
        services.Configure<IdentityOptions>(options =>
        {
            
            options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;
            
        });
        builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromMinutes(30);
        });

        services.AddTransient<IUserTwoFactorTokenProvider<Users>, JwtTokenProvider<Users>>();

        builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
        builder.AddEntityFrameworkStores<JungleJumboreeDbContext>();
        builder.AddSignInManager<SignInManager<Users>>();

        builder.AddTokenProvider("Default", typeof(JwtTokenProvider<Users>));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                    ValidateIssuer = true,
                    ValidIssuer = config["Token:Issuer"],
                    ValidateAudience = false 
                };
            });

        return services;
    }
}
