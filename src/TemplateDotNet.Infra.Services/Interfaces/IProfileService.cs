using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Application.UseCases.Profile.Common;
using TemplateDotNet.Application.UseCases.Profile.CreateProfile;
using TemplateDotNet.Application.UseCases.Profile.UpdateProfile;
using TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Infra.Services.Interfaces;
public interface IProfileService
{
    Task<ProfileOutput> Insert(CreateProfileInput input);
    Task<ProfileOutput> Update(Guid id, UpdateProfileInput input);
    Task<PaginationOutput<ProfileOutput>> GetAll(PaginationInput input);
    Task<ProfileOutput?> GetById(Guid id);
    Task<bool> Delete(Guid id);
}
