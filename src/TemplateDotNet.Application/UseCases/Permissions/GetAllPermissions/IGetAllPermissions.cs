using TemplateDotNet.Application.Interfaces;

namespace TemplateDotNet.Application.UseCases.Permissions.GetAllPermissions;
public interface IGetAllPermissions 
    : IHandler<Guid, PermissionsOutput>
{
}
