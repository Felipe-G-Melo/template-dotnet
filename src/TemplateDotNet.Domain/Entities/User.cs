using BarberShopOnline.Application.Cryphtography;
using TemplateDotNet.Domain.Exceptions;
using TemplateDotNet.Domain.SeedWork;
using TemplateDotNet.Domain.SeedWork.Validations;

namespace TemplateDotNet.Domain.Entities;
public class User : BaseEntity
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Guid ProfileId { get; private set; }
    public Profile? Profile { get; private set; }

    public User(string username, string email, string password, Guid profileId)
    {
        Username = username;
        Email = email;
        Password = password;
        ProfileId = profileId;
        Validate();
    }

    public void Update(string username, string email, string password, Guid profileId)
    {
        Username = username;
        Email = email;
        Password = password;
        ProfileId = profileId;
        UpdatedAt = DateTime.UtcNow;
        Validate();
    }

    public void EncryptPassword()
    {
        Password = Password.Encrypt();
    }

    private void Validate()
    {
        if(string.IsNullOrEmpty(Username))
            throw new EntityValidationException("Username is required");
        if(Username.Length < 3)
            throw new EntityValidationException("Username must be at least 3 characters");
        if(string.IsNullOrEmpty(Email))
            throw new EntityValidationException("Email is required");
        if(!Email.IsValidEmail())
            throw new EntityValidationException("Email is invalid");
        if(string.IsNullOrEmpty(Password))
            throw new EntityValidationException("Password is required");
        if (Password.Length < 6)
            throw new EntityValidationException("Password must be at least 6 characters");
        if(ProfileId == Guid.Empty)
            throw new EntityValidationException("Profile is required");
    }
}
