using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.User.Common;

namespace TemplateDotNet.Application.UseCases.User.UpdateUser;
public interface IUpdateUser 
    : IHandler<UpdateUserInput, UserOutput>
{
}
