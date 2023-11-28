using TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Application.UseCases.Permissions.GetAllPermissions;
public class PermissionsOutput
{
    public List<MenuOutput> Menus { get; private set; }

    public PermissionsOutput(List<MenuOutput> menus)
        => Menus = menus;

    public static PermissionsOutput FromOutput(List<Menu> menus)
        => new (menus.Select(x => new MenuOutput
        {
            Id = x.Id,
            Icon = x.Icon,
            Name = x.Name,
            SubMenus = x.SubMenus.Select(y => new SubMenuOutput
            {
                Icon = y.Icon,
                Name = y.Name,
                Path = y.Path
            }).ToList()
        }).ToList());
    
}

public class MenuOutput
{
    public Guid Id { get; set; }
    public string Icon { get; set; }
    public string Name { get; set; }
    public List<SubMenuOutput> SubMenus { get; set; }
}

public class SubMenuOutput
{
    public string Icon { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
}