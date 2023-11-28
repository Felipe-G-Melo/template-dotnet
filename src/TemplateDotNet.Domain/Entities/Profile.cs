using TemplateDotNet.Domain.Exceptions;
using TemplateDotNet.Domain.SeedWork;

namespace TemplateDotNet.Domain.Entities;
public class Profile : BaseEntity
{
    public string Name { get; private set; }
    public List<User>? Users { get; private set; }
    public List<ProfilesSubMenus>? ProfilesSubMenus { get; private set; }

    public Profile(string name)
    {
        Name = name;
        Validate();
    }

    public void Update(string name)
    {
        Name = name;
        UpdatedAt = DateTime.UtcNow;
        Validate();
    }

    private void Validate()
    {
        if(string.IsNullOrEmpty(Name))
            throw new EntityValidationException("Name is required");
        if(Name.Length < 3)
            throw new EntityValidationException("Name must be greater than 3 characters");
    }
}
