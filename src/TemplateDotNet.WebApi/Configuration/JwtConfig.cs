using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TemplateDotNet.WebApi.Utils;

namespace TemplateDotNet.WebApi.Configuration;

public static class JwtConfig
{
    public static IServiceCollection AddJwtConfiguration(
        this IServiceCollection services
        )
    {
        var appSettings = new AppSettings();
        var key = Encoding.ASCII.GetBytes(appSettings!.Secret);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = true;
            x.SaveToken = true;
            x.TokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = appSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = appSettings.ValidAt,
            };
        });

        return services;
    }
}
