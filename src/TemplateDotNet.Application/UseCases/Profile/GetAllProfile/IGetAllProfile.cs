using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.Profile.Common;

namespace TemplateDotNet.Application.UseCases.Profile.GetAllProfile;
public interface IGetAllProfile
    : IHandler<PaginationInput, PaginationOutput<ProfileOutput>>
{
}
