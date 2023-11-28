using BarberShopOnline.Application.Cryphtography;
using Entity = TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.User.GetUserByEmailAndPassword;
public class GetUserByEmailAndPassword : IGetUserByEmailAndPassword
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailAndPassword(IUserRepository userRepository)
        => _userRepository = userRepository;
    

    public async Task<Entity.User> Handle(GetUserByEmailAndPasswordInput input)
    {
        var user =  await _userRepository.GetUserByEmailAndPassword(input.Email, input.Password.Encrypt());
        if(user == null)
            throw new Exception("Invalid user or password");

        return user;
    }
}
