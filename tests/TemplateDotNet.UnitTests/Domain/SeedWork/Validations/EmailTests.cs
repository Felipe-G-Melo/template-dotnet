using TemplateDotNet.Domain.SeedWork.Validations;
using Xunit;

namespace TemplateDotNet.UnitTests.Domain.SeedWork.Validations;
public class EmailTests
{
    [Theory(DisplayName = nameof(EmailInvalid))]
    [Trait("Domain", "SeedWork - EmailValidator")]
    [InlineData("felipeteste.com")]
    [InlineData("felipe@teste")]
    [InlineData("felipe@teste.")]
    public void EmailInvalid(string email)
    {
        var result = email.IsValidEmail();

        Assert.False(result);
    }

    [Theory(DisplayName = nameof(EmailValid))]
    [Trait("Domain", "SeedWork - EmailValidator")]
    [InlineData("feelipe@gmail.com")]
    [InlineData("pedro@gmail.com")]
    [InlineData("gustavo@gmail.com")]
    public void EmailValid(string email)
    {
        var result = email.IsValidEmail();

        Assert.True(result);
    }
}
