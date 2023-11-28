using TemplateDotNet.Application.Common.Pagination;
using TemplateDotNet.Application.UseCases.User.Common;
using TemplateDotNet.Application.UseCases.User.CreateUser;
using TemplateDotNet.Application.UseCases.User.DeleteUser;
using TemplateDotNet.Application.UseCases.User.GetAllUser;
using TemplateDotNet.Application.UseCases.User.GetUserById;
using TemplateDotNet.Application.UseCases.User.UpdateUser;
using TemplateDotNet.Infra.Services.Interfaces;

namespace TemplateDotNet.Infra.Services.Services;
public class UserService : IUserService
{
    private readonly ICreateUser _createUser;
    private readonly IUpdateUser _updateUser;
    private readonly IGetAllUser _getAllUser;
    private readonly IGetUserById _getByIdUser;
    private readonly IDeleteUser _deleteUser;

    public UserService(
        ICreateUser createUser,
        IUpdateUser updateUser,
        IGetAllUser getAllUser,
        IGetUserById getByIdUser,
        IDeleteUser deleteUser
    )
    {
        _createUser = createUser;
        _updateUser = updateUser;
        _getAllUser = getAllUser;
        _getByIdUser = getByIdUser;
        _deleteUser = deleteUser;
    }

    public async Task<UserOutput> Insert(CreateUserInput input)
    {
        return await _createUser.Handle(input);
    }

    public async Task<UserOutput> Update(Guid id, UpdateUserInput input)
    {
        if(id != input.Id)
            throw new Exception("Id is not equal to input id");
        return await _updateUser.Handle(input);
    }

    public async Task<PaginationOutput<UserOutput>> GetAll(PaginationInput input)
    {
        return await _getAllUser.Handle(input);
    }

    public async Task<UserOutput?> GetById(Guid id)
    {
        return await _getByIdUser.Handle(id);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await _deleteUser.Handle(id);
    }

}
