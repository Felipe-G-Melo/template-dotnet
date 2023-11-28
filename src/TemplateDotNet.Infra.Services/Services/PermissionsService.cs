using TemplateDotNet.Application.UseCases.Permissions.GetAllPermissions;
using TemplateDotNet.Infra.Services.Interfaces;

namespace TemplateDotNet.Infra.Services.Services;
public class PermissionsService : IPermissionsService
{
    private readonly IGetAllPermissions _getAllPermissions;

    public PermissionsService(IGetAllPermissions getAllPermissions)
        => _getAllPermissions = getAllPermissions;

    public async Task<PermissionsOutput> GetAllPermissions(Guid profileId)
    {
        return await _getAllPermissions.Handle(profileId);
    }
}
