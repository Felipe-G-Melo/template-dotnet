using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.User.DeleteUser;
public class DeleteUser : IDeleteUser
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUser(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    )
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(Guid input)
    {
        var user = await _userRepository.GetById(input);
        await _userRepository.Delete(input);
        await _unitOfWork.Commit();

        return true;
    }
}
