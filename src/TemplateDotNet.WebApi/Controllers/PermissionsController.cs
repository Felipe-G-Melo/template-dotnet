using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateDotNet.Application.UseCases.Permissions.GetAllPermissions;
using TemplateDotNet.Infra.Services.Interfaces;

namespace TemplateDotNet.WebApi.Controllers;
[Route("api/permissions")]
[Authorize]
[ApiController]
public class PermissionsController : ControllerBase
{
    private readonly IPermissionsService _permissionService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PermissionsController(
        IPermissionsService permissionService,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _permissionService = permissionService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<ActionResult<List<PermissionsOutput>>> GetPermissions()
    {
        try
        {
            var profileId = new Guid(_httpContextAccessor.HttpContext!.User!.FindFirst("profileId")!.Value);
            return Ok(await _permissionService.GetAllPermissions(profileId));
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
