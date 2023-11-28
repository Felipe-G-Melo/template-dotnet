using System.Text.RegularExpressions;

namespace TemplateDotNet.Domain.SeedWork.Validations;
public static class Email
{
    public static bool IsValidEmail(this string email)
    {
        return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    }
}
