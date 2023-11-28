using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.Profile.DeleteProfile;
public class DeleteProfile : IDeleteProfile
{
    private readonly IProfileRepository _profileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProfile(
        IProfileRepository profileRepository,
        IUnitOfWork unitOfWork
    )
    {
        _profileRepository = profileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(Guid input)
    {
        await _profileRepository.Delete(input);
        await _unitOfWork.Commit();

        return true;
    }
}
