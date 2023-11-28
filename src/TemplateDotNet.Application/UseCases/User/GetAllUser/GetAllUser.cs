using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Application.UseCases.User.Common;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.User.GetAllUser;
public class GetAllUser : IGetAllUser
{
    private readonly IUserRepository _userRepository;

    public GetAllUser(IUserRepository userRepository)
        => _userRepository = userRepository;
    
    public async Task<PaginationOutput<UserOutput>> Handle(PaginationInput input)
    {
        var users = await _userRepository.GetAll(input);
        var outputUser = new List<UserOutput>();
        foreach(var user in users.Data)
        {
            outputUser.Add(UserOutput.FromOutput(user));
        }
        
        return PaginationOutput<UserOutput>.FromOutput(users.Total, outputUser);
    }
}
