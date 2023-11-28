using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.Profile.Common;

namespace TemplateDotNet.Application.UseCases.Profile.CreateProfile;
public interface ICreateProfile 
    : IHandler<CreateProfileInput, ProfileOutput>
{
}
