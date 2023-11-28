namespace TemplateDotNet.Application.Interfaces;
public interface IUnitOfWork
{
    Task Commit();
}
