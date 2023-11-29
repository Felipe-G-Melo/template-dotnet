using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.Profile.Common;
using TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.Profile.UpdateProfile;
public class UpdateProfile : IUpdateProfile
{
    private readonly IProfileRepository _profileRepository;
    private readonly ISubMenuRepository _subMenuRepository;
    private readonly IProfilesSubMenusRepository _profilesSubMenusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProfile(
        IProfileRepository profileRepository,
        ISubMenuRepository subMenuRepository,
        IProfilesSubMenusRepository profilesSubMenusRepository,
        IUnitOfWork unitOfWork
    )
    {
        _profileRepository = profileRepository;
        _subMenuRepository = subMenuRepository;
        _profilesSubMenusRepository = profilesSubMenusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProfileOutput> Handle(UpdateProfileInput input)
    {
        var profile = await _profileRepository.GetById(input.Id);
        var validate = new VerifySubMenu(_subMenuRepository, input.ProfilesSubMenus);
        await validate.IfExists();
        validate.IsEmpty(input.ProfilesSubMenus);
        
        profile!.Update(input.Name);
        var existingSubMenus = profile.ProfilesSubMenus!.Where(x => x.ProfileId == profile.Id).ToList();
        _profilesSubMenusRepository.RemoveRange(existingSubMenus);
        await AddSubMenu.Add(_profilesSubMenusRepository, input.ProfilesSubMenus, profile.Id);

        await _unitOfWork.Commit();

        return ProfileOutput.FromOutput(profile);
    }
}
