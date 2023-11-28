using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Application.UseCases.Profile.Common;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.Profile.GetAllProfile;
public class GetAllProfile : IGetAllProfile
{
    private readonly IProfileRepository _profileRepository;

    public GetAllProfile(IProfileRepository profileRepository)
        => _profileRepository = profileRepository;
    
    public async Task<PaginationOutput<ProfileOutput>> Handle(PaginationInput input)
    {
        var profiles = await _profileRepository.GetAll(input);
        var outputProfile = new List<ProfileOutput>();
        foreach (var profile in profiles.Data)
        {
            outputProfile.Add(ProfileOutput.FromOutput(profile));
        }

        return PaginationOutput<ProfileOutput>.FromOutput(profiles.Total, outputProfile);
    }
}
