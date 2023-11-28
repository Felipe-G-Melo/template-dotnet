using Microsoft.AspNetCore.Mvc;
using TemplateDotNet.Application.UseCases.User.GetUserByEmailAndPassword;
using TemplateDotNet.Infra.Services.Interfaces;

namespace TemplateDotNet.WebApi.Controllers;
[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
        => _loginService = loginService;

    [HttpPost]
    public async Task<ActionResult<string>> Login(GetUserByEmailAndPasswordInput input)
    {
        try
        {
            var token = await _loginService.Login(input);
            return Ok(token);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
