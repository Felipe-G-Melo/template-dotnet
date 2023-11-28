using TemplateDotNet.Application.UseCases.Permissions.GetAllPermissions;

namespace TemplateDotNet.Infra.Services.Interfaces;
public interface IPermissionsService
{
    Task<PermissionsOutput> GetAllPermissions(Guid profileId);
}
