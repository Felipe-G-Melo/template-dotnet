using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.User.Common;

namespace TemplateDotNet.Application.UseCases.User.GetAllUser;
public interface IGetAllUser 
    : IHandler<PaginationInput, PaginationOutput<UserOutput>>
{
}
