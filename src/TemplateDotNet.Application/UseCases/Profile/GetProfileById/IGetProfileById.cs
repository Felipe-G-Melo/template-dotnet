using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.Profile.Common;

namespace TemplateDotNet.Application.UseCases.Profile.GetProfileById;
public interface IGetProfileById
    : IHandler<Guid, ProfileOutput>
{
}
