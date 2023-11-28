using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.Profile.Common;
using TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Exceptions;
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
        if (input.ProfilesSubMenus == null || input.ProfilesSubMenus!.Count < 0)
            throw new EntityValidationException("Sub menus is required");
        var validate = new VerifyIfSubMenuExists(_subMenuRepository, input.ProfilesSubMenus);
        await validate.Handle();
        var profile = await _profileRepository.GetById(input.Id);
        
        profile!.Update(input.Name);

        var newProfilesSubMenus = input.ProfilesSubMenus
            .Select(profilesSubMenus => profilesSubMenus.SubMenuId).ToList()
            .Except(
                profile.ProfilesSubMenus!.Select(profilesSubMenus => profilesSubMenus.SubMenuId).ToList())
            .Select(subMenuId => new ProfilesSubMenus(subMenuId, profile!.Id)).ToList();

        var oldProfilesSubMenus = profile.ProfilesSubMenus!
            .Select(profilesSubMenus => profilesSubMenus.SubMenuId).ToList()
            .Except(
                input.ProfilesSubMenus.Select(profilesSubMenus => profilesSubMenus.SubMenuId).ToList())
            .Select(subMenuId => profile.ProfilesSubMenus
                           .FirstOrDefault(profilesSubMenus => profilesSubMenus.SubMenuId == subMenuId)).ToList();

        foreach (var item in newProfilesSubMenus)
        {
            await _profilesSubMenusRepository.Insert(item);
        }
        foreach (var item in oldProfilesSubMenus)
        {
            await _profilesSubMenusRepository.Delete(item!.Id);
        }

        await _unitOfWork.Commit();

        return ProfileOutput.FromOutput(profile);
    }
}


