using Microsoft.EntityFrameworkCore;
using TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Infra.Data.EF.Repositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(TemplateDotNetDbContext context) 
        : base(context)
    { }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> GetUserByEmailAndPassword(string email, string password)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
    }
}