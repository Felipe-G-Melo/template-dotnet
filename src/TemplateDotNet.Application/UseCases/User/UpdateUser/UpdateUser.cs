using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.User.Common;
using TemplateDotNet.Domain.Exceptions;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.User.UpdateUser;
public class UpdateUser : IUpdateUser
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUser(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    )
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserOutput> Handle(UpdateUserInput input)
    {
        await VerifyIfEmailAlreadyExists(input.Id, input.Email);
        var user = await _userRepository.GetById(input.Id);
        user!.Update(
            input.Username,
            input.Email, 
            input.Password ?? user.Password,
            input.ProfileId
            );
        if(input.Password != null)
            user.EncryptPassword();

        await _unitOfWork.Commit();

        return UserOutput.FromOutput(user);
    }

    private async Task VerifyIfEmailAlreadyExists(Guid id, string email)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if (user != null && user.Id != id)
            throw new EntityValidationException("Email already exists");
    }
}
