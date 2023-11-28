using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Application.UseCases.Profile.Common;
using TemplateDotNet.Application.UseCases.Profile.CreateProfile;
using TemplateDotNet.Application.UseCases.Profile.UpdateProfile;
using TemplateDotNet.Infra.Services.Interfaces;

namespace TemplateDotNet.WebApi.Controllers;
[Route("api/profile")]
[Authorize]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpPost]
    public async Task<ActionResult<ProfileOutput>> Create(CreateProfileInput input)
    {
        try
        {
            return Ok(await _profileService.Insert(input));
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProfileOutput>> Update(Guid id, UpdateProfileInput input)
    {
        try
        {
            return Ok(await _profileService.Update(id, input));
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<PaginationOutput<ProfileOutput>>> GetAll([FromQuery] PaginationInput input)
    {
        try
        {
            return Ok(await _profileService.GetAll(input));
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProfileOutput>> GetById(Guid id)
    {
        try
        {
            return Ok(await _profileService.GetById(id));
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        try
        {
            return Ok(await _profileService.Delete(id));
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
