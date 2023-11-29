using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.Profile.Common;
using TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Repositories;
using Entity = TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Application.UseCases.Profile.CreateProfile;
public class CreateProfile : ICreateProfile
{
    private readonly IProfileRepository _profileRepository;
    private readonly ISubMenuRepository _subMenuRepository;
    private readonly IProfilesSubMenusRepository _profilesSubMenusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProfile(
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

    public async Task<ProfileOutput> Handle(CreateProfileInput input)
    {
        var validate = new VerifySubMenu(_subMenuRepository, input.ProfilesSubMenus);
        await validate.IfExists();
        validate.IsEmpty(input.ProfilesSubMenus);

        var profile = new Entity.Profile(input.Name);
        await AddSubMenu.Add(_profilesSubMenusRepository, input.ProfilesSubMenus, profile.Id);

        await _profileRepository.Insert(profile);
        await _unitOfWork.Commit();

        return ProfileOutput.FromOutput(profile);
    }
}
