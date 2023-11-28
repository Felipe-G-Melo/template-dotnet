using TemplateDotNet.Application.Interfaces;
using Entity = TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Application.UseCases.User.GetUserByEmailAndPassword;
public interface IGetUserByEmailAndPassword
    : IHandler<GetUserByEmailAndPasswordInput, Entity.User>
{
}
