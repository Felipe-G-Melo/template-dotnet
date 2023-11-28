using TemplateDotNet.Application.UseCases.User.GetUserByEmailAndPassword;
using TemplateDotNet.WebApi.Utils;

namespace TemplateDotNet.Infra.Services.Interfaces;
public interface ILoginService
{
    Task<LoginOutput> Login(GetUserByEmailAndPasswordInput input);
}
