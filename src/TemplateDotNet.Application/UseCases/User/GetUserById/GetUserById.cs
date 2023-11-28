using TemplateDotNet.Application.UseCases.User.Common;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.User.GetUserById;
public class GetUserById : IGetUserById
{
    private readonly IUserRepository _userRepository;

    public GetUserById(IUserRepository userRepository)
        => _userRepository = userRepository;

    public async Task<UserOutput> Handle(Guid input)
    {
        var user = await _userRepository.GetById(input);

        return UserOutput.FromOutput(user);
    }
}
