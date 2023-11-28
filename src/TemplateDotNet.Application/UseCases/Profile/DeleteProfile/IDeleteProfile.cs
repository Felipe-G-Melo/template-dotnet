using TemplateDotNet.Application.Interfaces;

namespace TemplateDotNet.Application.UseCases.Profile.DeleteProfile;
public interface IDeleteProfile 
    : IHandler<Guid, bool>
{
}
