using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.User.Common;

namespace TemplateDotNet.Application.UseCases.User.GetUserById;
public interface IGetUserById : IHandler<Guid, UserOutput>
{
}
