using TemplateDotNet.Application.Interfaces;
using Entity = TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Repositories;
using TemplateDotNet.Application.UseCases.User.Common;
using TemplateDotNet.Domain.Exceptions;

namespace TemplateDotNet.Application.UseCases.User.CreateUser;
public class CreateUser : ICreateUser
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IProfileRepository _profileRepository;

    public CreateUser(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IProfileRepository profileRepository
    )
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _profileRepository = profileRepository;
    }

    public async Task<UserOutput> Handle(CreateUserInput input)
    {
        await _profileRepository.GetById(input.ProfileId);
        await VerifyIfEmailAlreadyExists(input.Email);
        var user = new Entity.User(
            input.Username,
            input.Email,
            input.Password,
            input.ProfileId
            );
        user.EncryptPassword();
        await _userRepository.Insert(user);
        await _unitOfWork.Commit();

        return UserOutput.FromOutput(user);
    }

    private async Task VerifyIfEmailAlreadyExists(string email)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if(user != null)
            throw new EntityValidationException("Email already exists");
    }
}
