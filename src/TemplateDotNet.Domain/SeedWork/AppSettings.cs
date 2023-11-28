namespace TemplateDotNet.WebApi.Utils;

public class AppSettings
{
    public string Secret { get; } = "fedaf7d8863b48e197b9287d492b708e";
    public int ExpirationHours { get; } = 2;
    public string Issuer { get; } = "TemplateDotNet";
    public string ValidAt { get; } = "http://localhost";
}
