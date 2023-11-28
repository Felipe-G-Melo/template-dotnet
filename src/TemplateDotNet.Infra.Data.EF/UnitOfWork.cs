using TemplateDotNet.Application.Interfaces;

namespace TemplateDotNet.Infra.Data.EF;
public class UnitOfWork : IUnitOfWork
{
    private readonly TemplateDotNetDbContext _context;

    public UnitOfWork(TemplateDotNetDbContext context)
        => _context = context;

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}
