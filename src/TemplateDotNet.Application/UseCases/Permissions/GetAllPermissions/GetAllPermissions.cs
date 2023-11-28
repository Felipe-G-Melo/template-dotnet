using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.Permissions.GetAllPermissions;
public class GetAllPermissions : IGetAllPermissions
{
    private readonly IMenuRepository _menuRepository;

    public GetAllPermissions(IMenuRepository menuRepository)
        => _menuRepository = menuRepository;

    public async Task<PermissionsOutput> Handle(Guid input)
    {
        var menus = await _menuRepository.GetByProfileId(input);

        return PermissionsOutput.FromOutput(menus);
    }
}