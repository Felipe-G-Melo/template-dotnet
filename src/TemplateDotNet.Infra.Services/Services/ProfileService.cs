using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Application.UseCases.Profile.Common;
using TemplateDotNet.Application.UseCases.Profile.CreateProfile;
using TemplateDotNet.Application.UseCases.Profile.DeleteProfile;
using TemplateDotNet.Application.UseCases.Profile.GetAllProfile;
using TemplateDotNet.Application.UseCases.Profile.GetProfileById;
using TemplateDotNet.Application.UseCases.Profile.UpdateProfile;
using TemplateDotNet.Infra.Services.Interfaces;

namespace TemplateDotNet.Infra.Services.Services;
public class ProfileService : IProfileService
{
    private readonly ICreateProfile _createProfile;
    private readonly IUpdateProfile _updateProfile;
    private readonly IGetAllProfile _getAllProfile;
    private readonly IGetProfileById _getProfileById;
    private readonly IDeleteProfile _deleteProfile;

    public ProfileService(
        ICreateProfile createProfile,
        IUpdateProfile updateProfile,
        IGetAllProfile getAllProfile,
        IGetProfileById getProfileById,
        IDeleteProfile deleteProfile
    )
    {
        _createProfile = createProfile;
        _updateProfile = updateProfile;
        _getAllProfile = getAllProfile;
        _getProfileById = getProfileById;
        _deleteProfile = deleteProfile;
    }

    public async Task<ProfileOutput> Insert(CreateProfileInput input)
    {
        return await _createProfile.Handle(input);
    }

    public async Task<ProfileOutput> Update(Guid id, UpdateProfileInput input)
    {
        if (id != input.Id)
            throw new Exception("Id is not valid");

        return await _updateProfile.Handle(input);
    }

    public async Task<PaginationOutput<ProfileOutput>> GetAll(PaginationInput input)
    {
        return await _getAllProfile.Handle(input);
    }

    public async Task<ProfileOutput?> GetById(Guid id)
    {
        return await _getProfileById.Handle(id);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await _deleteProfile.Handle(id);
    }
}
