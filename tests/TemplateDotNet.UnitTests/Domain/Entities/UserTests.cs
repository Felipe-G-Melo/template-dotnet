using TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Exceptions;
using Xunit;

namespace TemplateDotNet.UnitTests.Domain.Entities;
public class UserTests
{
    [Fact(DisplayName = nameof(Instantiate))]
    [Trait("Domain", "Entity - User")]
    public void Instantiate()
    {
        var profileId = Guid.NewGuid();
        var currentDateTime = DateTime.UtcNow;
        int margemErroMilissegundos = 100;

        var user = new User(
            "felipe_melo",
            "felipe@gmail.com",
            "12345678",
             profileId
            );

        Assert.NotNull(user);
        Assert.NotEqual(Guid.Empty, user.Id);
        Assert.True(Math.Abs((user.CreatedAt - currentDateTime).TotalMilliseconds) <= margemErroMilissegundos);
        Assert.True(Math.Abs((user.UpdatedAt - currentDateTime).TotalMilliseconds) <= margemErroMilissegundos);
        Assert.Equal("felipe_melo", user.Username);
        Assert.Equal("felipe@gmail.com", user.Email);
        Assert.Equal("12345678", user.Password);
        Assert.Equal(profileId, user.ProfileId);
    }

    [Theory(DisplayName = nameof(ErrorWhenInstantiateUserWithUsernameEmptyOrNull))]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Entity - User")]
    public void ErrorWhenInstantiateUserWithUsernameEmptyOrNull(string? invalidUsername)
    {
        var profileId = Guid.NewGuid();
        var validUser = new User(
            "felipe_melo",
            "felipe@gmail.com",
            "12345678",
             profileId
            );

        Exception exception = Assert.Throws<EntityValidationException>(() => new User(
            invalidUsername,
            validUser.Email,
            validUser.Password,
            validUser.ProfileId
        ));
        Assert.Equal("Username is required", exception.Message);
    }

    [Theory(DisplayName = nameof(ErrorWhenInstantiateUserWithUsernameLessThan3Characters))]
    [InlineData("as")]
    [InlineData("a")]
    [Trait("Domain", "Entity - User")]
    public void ErrorWhenInstantiateUserWithUsernameLessThan3Characters(string? invalidUsername)
    {
        var profileId = Guid.NewGuid();
        var validUser = new User(
            "felipe_melo",
            "felipe@gmail.com",
            "12345678",
             profileId
            );

        Exception exception = Assert.Throws<EntityValidationException>(() => new User(
            invalidUsername,
            validUser.Email,
            validUser.Password,
            validUser.ProfileId
        ));
        Assert.Equal("Username must be at least 3 characters", exception.Message);
    }

    [Theory(DisplayName = nameof(ErrorWhenInstantiateUserWithEmailEmptyOrNull))]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Entity - User")]
    public void ErrorWhenInstantiateUserWithEmailEmptyOrNull(string? invalidEmail)
    {
        var profileId = Guid.NewGuid();
        var validUser = new User(
            "felipe_melo",
            "felipe@gmail.com",
            "12345678",
             profileId
            );

        Exception exception = Assert.Throws<EntityValidationException>(() => new User(
            validUser.Username,
            invalidEmail,
            validUser.Password,
            validUser.ProfileId
        ));
        Assert.Equal("Email is required", exception.Message);
    }

    [Theory(DisplayName = nameof(ErrorWhenInstantiateUserWithUsernameLessThan3Characters))]
    [InlineData("felipe@teste.")]
    [InlineData("felipeteste.")]
    [InlineData("felipeteste.com")]
    [Trait("Domain", "Entity - User")]
    public void ErrorWhenInstantiateUserWithInvalidEmaiil(string? invalidEmail)
    {
        var profileId = Guid.NewGuid();
        var validUser = new User(
            "felipe_melo",
            "felipe@gmail.com",
            "12345678",
             profileId
            );

        Exception exception = Assert.Throws<EntityValidationException>(() => new User(
            validUser.Username,
            invalidEmail,
            validUser.Password,
            validUser.ProfileId
        ));
        Assert.Equal("Email is invalid", exception.Message);
    }

    [Theory(DisplayName = nameof(ErrorWhenInstantiateUserWithPasswordEmptyOrNull))]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Entity - User")]
    public void ErrorWhenInstantiateUserWithPasswordEmptyOrNull(string? invalidPassword)
    {
        var profileId = Guid.NewGuid();
        var validUser = new User(
            "felipe_melo",
            "felipe@gmail.com",
            "12345678",
             profileId
            );

        Exception exception = Assert.Throws<EntityValidationException>(() => new User(
            validUser.Username,
            validUser.Email,
            invalidPassword,
            validUser.ProfileId
        ));
        Assert.Equal("Password is required", exception.Message);
    }

    [Theory(DisplayName = nameof(ErrorWhenInstantiateUserWithPasswordLessThan3Characters))]
    [InlineData("1684")]
    [InlineData("12ofg")]
    [InlineData("ofg")]
    [Trait("Domain", "Entity - User")]
    public void ErrorWhenInstantiateUserWithPasswordLessThan3Characters(string? invalidPassword)
    {
        var profileId = Guid.NewGuid();
        var validUser = new User(
            "felipe_melo",
            "felipe@gmail.com",
            "12345678",
             profileId
            );

        Exception exception = Assert.Throws<EntityValidationException>(() => new User(
            validUser.Username,
            validUser.Email,
            invalidPassword,
            validUser.ProfileId
        ));
        Assert.Equal("Password must be at least 6 characters", exception.Message);
    }

    [Theory(DisplayName = nameof(ErrorWhenInstantiateUserWithPasswordGreaterThan12Characters))]
    [InlineData("1234567891011")]
    [InlineData("kdjgnisedrhgirhfg")]
    [InlineData("çkewrjgtggthio")]
    [Trait("Domain", "Entity - User")]
    public void ErrorWhenInstantiateUserWithPasswordGreaterThan12Characters(string? invalidPassword)
    {
        var profileId = Guid.NewGuid();
        var validUser = new User(
            "felipe_melo",
            "felipe@gmail.com",
            "12345678",
             profileId
            );

        Exception exception = Assert.Throws<EntityValidationException>(() => new User(
            validUser.Username,
            validUser.Email,
            invalidPassword,
            validUser.ProfileId
        ));
        Assert.Equal("Password must be less than 12 characters", exception.Message);
    }

    [Fact(DisplayName = nameof(ErrorWhenInstantiateUserWithProfileIdEmpty))]
    [Trait("Domain", "Entity - User")]
    public void ErrorWhenInstantiateUserWithProfileIdEmpty()
    {
        var invalidProfileId = Guid.Empty;
        var validUser = new User(
            "felipe_melo",
            "felipe@gmail.com",
            "12345678",
             Guid.NewGuid()
            );

        Exception exception = Assert.Throws<EntityValidationException>(() => new User(
            validUser.Username,
            validUser.Email,
            validUser.Password,
            invalidProfileId
        ));
        Assert.Equal("Profile is required", exception.Message);
    }

    [Fact(DisplayName = nameof(Update))]
    [Trait("Domain", "Entity - User")]
    public void Update()
    {
        var profileId = Guid.NewGuid();
        var user = new User(
            "felipe_melo",
            "felipe@gmail.com",
            "12345678",
             profileId
            );
        var oldUpdatedAt = user.UpdatedAt;

        user.Update(
            "felipe_melo2",
            "felipe2@gmail.com",
            "87654321",
             profileId
            );

        Assert.True(user.UpdatedAt > oldUpdatedAt);
        Assert.Equal("felipe_melo2", user.Username);
        Assert.Equal("felipe2@gmail.com", user.Email);
        Assert.Equal("87654321", user.Password);
        Assert.Equal(profileId, user.ProfileId);
    }
}
