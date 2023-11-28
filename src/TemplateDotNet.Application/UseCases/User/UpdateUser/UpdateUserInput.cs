namespace TemplateDotNet.Application.UseCases.User.UpdateUser;
public class UpdateUserInput
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string? Password { get; private set; }
    public Guid ProfileId { get; private set; }

    public UpdateUserInput(
        Guid id,
        Guid profileId,
        string username,
        string email,
        string? password
    )
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        ProfileId = profileId;
    }
}
