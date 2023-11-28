using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.User.Common;

namespace TemplateDotNet.Application.UseCases.User.CreateUser;
public interface ICreateUser 
    : IHandler<CreateUserInput, UserOutput>
{
}
