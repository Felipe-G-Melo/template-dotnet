namespace TemplateDotNet.WebApi.Utils;

public class LoginOutput
{
    public string Token { get; private set; }
    public string RefreshToken { get; private set; }

    public LoginOutput(string token, string refreshToken)
    {
        Token = token;
        RefreshToken = refreshToken;
    }
}
