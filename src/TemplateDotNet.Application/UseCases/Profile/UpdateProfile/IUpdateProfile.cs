using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.Profile.Common;

namespace TemplateDotNet.Application.UseCases.Profile.UpdateProfile;
public interface IUpdateProfile 
    : IHandler<UpdateProfileInput, ProfileOutput>
{
}
