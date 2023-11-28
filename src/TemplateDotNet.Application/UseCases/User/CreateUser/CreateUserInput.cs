namespace TemplateDotNet.Application.UseCases.User.CreateUser;
public class CreateUserInput
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Guid ProfileId { get; private set; }

    public CreateUserInput(
        string username,
        string email,
        string password,
        Guid profileId
    )
    {
        Username = username;
        Email = email;
        Password = password;
        ProfileId = profileId;
    }
}
