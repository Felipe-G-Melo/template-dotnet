using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Application.UseCases.User.Common;
using TemplateDotNet.Application.UseCases.User.CreateUser;
using TemplateDotNet.Application.UseCases.User.UpdateUser;

namespace TemplateDotNet.Infra.Services.Interfaces;
public interface IUserService
{
    Task<UserOutput> Insert(CreateUserInput input);
    Task<UserOutput> Update(Guid id, UpdateUserInput input);
    Task<PaginationOutput<UserOutput>> GetAll(PaginationInput input);
    Task<UserOutput?> GetById(Guid id);
    Task<bool> Delete(Guid id);
}
