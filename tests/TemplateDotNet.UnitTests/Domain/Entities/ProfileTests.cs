using TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Exceptions;
using Xunit;

namespace TemplateDotNet.UnitTests.Domain.Entities;
public class ProfileTests
{
    [Fact(DisplayName = nameof(Instantiate))]
    [Trait("Domain", "Entity - Profile")]
    public void Instantiate()
    {
        var currentDateTime = DateTime.UtcNow;
        int margemErroMilissegundos = 100;

        var profile = new Profile(
            "Admin"
            );

        Assert.NotNull(profile);
        Assert.NotEqual(Guid.Empty, profile.Id);
        Assert.True(Math.Abs((profile.CreatedAt - currentDateTime).TotalMilliseconds) <= margemErroMilissegundos);
        Assert.True(Math.Abs((profile.UpdatedAt - currentDateTime).TotalMilliseconds) <= margemErroMilissegundos);
        Assert.Equal("Admin", profile.Name);
    }

    [Theory(DisplayName = nameof(ErrorWhenInstantiateProfileWithNameEmptyOrNull))]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Entity - Profile")]
    public void ErrorWhenInstantiateProfileWithNameEmptyOrNull(string? invalidName)
    {
        Exception exception = Assert.Throws<EntityValidationException>(() => new Profile(
            invalidName
        ));
        Assert.Equal("Name is required", exception.Message);
    }

    [Theory(DisplayName = nameof(ErrorWhenInstantiateProfileWithNameLessThan3Characters))]
    [InlineData("as")]
    [InlineData("a")]
    [Trait("Domain", "Entity - Profile")]
    public void ErrorWhenInstantiateProfileWithNameLessThan3Characters(string? invalidName)
    {
        Exception exception = Assert.Throws<EntityValidationException>(() => new Profile(
            invalidName
        ));
        Assert.Equal("Name must be greater than 3 characters", exception.Message);
    }

    [Fact(DisplayName = nameof(Update))]
    [Trait("Domain", "Entity - Profile")]
    public void Update()
    {
        var profile = new Profile(
            "Admin"
            );
        var oldUpdatedAt = profile.UpdatedAt;

        profile.Update("Admin2");

        Assert.True(profile.UpdatedAt > oldUpdatedAt);
        Assert.Equal("Admin2", profile.Name);
    }
}
