using TemplateDotNet.Application.Interfaces;

namespace TemplateDotNet.Application.UseCases.User.DeleteUser;
public interface IDeleteUser 
    : IHandler<Guid, bool>
{
}
