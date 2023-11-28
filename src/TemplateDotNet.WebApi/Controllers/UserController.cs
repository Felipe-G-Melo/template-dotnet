using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Application.UseCases.User.Common;
using TemplateDotNet.Application.UseCases.User.CreateUser;
using TemplateDotNet.Application.UseCases.User.UpdateUser;
using TemplateDotNet.Infra.Services.Interfaces;

namespace TemplateDotNet.WebApi.Controllers;
[Route("api/user")]
[Authorize]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<UserOutput>> Create(CreateUserInput input)
    {
        try
        {
            return Ok(await _userService.Insert(input));
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserOutput>> Update(Guid id, UpdateUserInput input)
    {
        try
        {
            return Ok(await _userService.Update(id, input));
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<PaginationOutput<UserOutput>>> GetAll([FromQuery] PaginationInput input)
    {
        try
        {
            return Ok(await _userService.GetAll(input));
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserOutput>> GetById(Guid id)
    {
        try
        {
            return Ok(await _userService.GetById(id));
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
            return Ok(await _userService.Delete(id));
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
