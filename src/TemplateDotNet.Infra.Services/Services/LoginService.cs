using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TemplateDotNet.Application.UseCases.User.GetUserByEmailAndPassword;
using TemplateDotNet.Domain.Entities;
using TemplateDotNet.Infra.Services.Interfaces;
using TemplateDotNet.WebApi.Utils;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace TemplateDotNet.Infra.Services.Services;
public class LoginService : ILoginService
{
    private readonly IGetUserByEmailAndPassword _getUserByEmailAndPassword;
    private readonly AppSettings _appSettings;

    public LoginService(IGetUserByEmailAndPassword getUserByEmailAndPassword)
    {
        _getUserByEmailAndPassword = getUserByEmailAndPassword;
        _appSettings = new AppSettings();
    }

    public async Task<LoginOutput> Login(GetUserByEmailAndPasswordInput input)
    {
        var user = await GetUserByEmailAndPassword(input);
        var token = await GenerateJwt(user);
        return new LoginOutput(token, ""); 
    }

    private async Task<User> GetUserByEmailAndPassword(GetUserByEmailAndPasswordInput input)
    {
        return await _getUserByEmailAndPassword.Handle(input);
    }

    private async Task<string> GenerateJwt(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("profileId", user.ProfileId.ToString()),
        };

        var identityClaims = new ClaimsIdentity();
        identityClaims.AddClaims(claims);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _appSettings.Issuer,
            Audience = _appSettings.ValidAt,
            Subject = identityClaims,
            Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHours),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature)
        });

        var encodedToken = tokenHandler.WriteToken(token);

        return encodedToken;
    }
}
