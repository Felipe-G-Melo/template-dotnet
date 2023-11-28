using System.Text.Json.Serialization;
using TemplateDotNet.Domain.SeedWork;

namespace TemplateDotNet.Domain.Entities;
public class ProfilesSubMenus : BaseEntity
{
    public Guid ProfileId { get; private set; }
    [JsonIgnore]
    public Profile? Profile { get; private set; }
    public Guid SubMenuId { get; private set; }
    [JsonIgnore]
    public SubMenu? SubMenu { get; private set; }
    

    public ProfilesSubMenus(Guid subMenuId, Guid profileId)
    {
        SubMenuId = subMenuId;
        ProfileId = profileId;
    }
}
