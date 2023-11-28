using Entity = TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Application.UseCases.User.Common;
public class UserOutput
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Guid ProfileId { get; private set; }

    public UserOutput(
        Guid id,
        string username,
        string email,
        string password,
        Guid profileId
    )
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        ProfileId = profileId;
    }

    public static UserOutput FromOutput(Entity.User user)
        => new(
            user.Id,
            user.Username,
            user.Email,
            user.Password,
            user.ProfileId
            );
}