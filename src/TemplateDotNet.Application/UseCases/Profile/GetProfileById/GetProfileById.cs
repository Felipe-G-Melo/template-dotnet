using TemplateDotNet.Application.UseCases.Profile.Common;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.Profile.GetProfileById;
public class GetProfileById : IGetProfileById
{
    private readonly IProfileRepository _profileRepository;

    public GetProfileById(IProfileRepository profileRepository)
        =>  _profileRepository = profileRepository;
    
    public async Task<ProfileOutput> Handle(Guid input)
    {
        var profile = await _profileRepository.GetById(input);
        return ProfileOutput.FromOutput(profile!);
    }
}
