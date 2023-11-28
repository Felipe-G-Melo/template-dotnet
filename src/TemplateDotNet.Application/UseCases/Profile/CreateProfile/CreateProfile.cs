using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.Profile.Common;
using TemplateDotNet.Domain.Exceptions;
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
        if (input.ProfilesSubMenus== null || input.ProfilesSubMenus!.Count < 0)
            throw new EntityValidationException("Sub menus is required");
        var validate = new VerifyIfSubMenuExists(_subMenuRepository, input.ProfilesSubMenus);
        await validate.Handle();

        var profile = new Entity.Profile(input.Name);
        var profilesSubMenus = 
            input.ProfilesSubMenus.Select(x => new Entity.ProfilesSubMenus(x.SubMenuId, profile.Id)).ToList();

        foreach(var item in profilesSubMenus)
        {
            _profilesSubMenusRepository.Insert(item);
        }

        await _profileRepository.Insert(profile);
        await _unitOfWork.Commit();

        return ProfileOutput.FromOutput(profile);
    }
}
