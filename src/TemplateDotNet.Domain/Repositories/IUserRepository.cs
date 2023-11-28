using TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Domain.Repositories;
public interface IUserRepository 
    : IGenericRepository<User>
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserByEmailAndPassword(string email, string password);
}
