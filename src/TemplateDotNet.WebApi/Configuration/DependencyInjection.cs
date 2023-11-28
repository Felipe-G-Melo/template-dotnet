using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.Permissions.GetAllPermissions;
using TemplateDotNet.Application.UseCases.Profile.CreateProfile;
using TemplateDotNet.Application.UseCases.Profile.DeleteProfile;
using TemplateDotNet.Application.UseCases.Profile.GetAllProfile;
using TemplateDotNet.Application.UseCases.Profile.GetProfileById;
using TemplateDotNet.Application.UseCases.Profile.UpdateProfile;
using TemplateDotNet.Application.UseCases.User.CreateUser;
using TemplateDotNet.Application.UseCases.User.DeleteUser;
using TemplateDotNet.Application.UseCases.User.GetAllUser;
using TemplateDotNet.Application.UseCases.User.GetUserByEmailAndPassword;
using TemplateDotNet.Application.UseCases.User.GetUserById;
using TemplateDotNet.Application.UseCases.User.UpdateUser;
using TemplateDotNet.Domain.Repositories;
using TemplateDotNet.Infra.Data.EF;
using TemplateDotNet.Infra.Data.EF.Repositories;
using TemplateDotNet.Infra.Services.Interfaces;
using TemplateDotNet.Infra.Services.Services;

namespace TemplateDotNet.WebApi.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositoryInjection(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<ISubMenuRepository, SubMenuRepository>();
        services.AddScoped<IProfilesSubMenusRepository, ProfilesSubMenusRepository>();

        return services;
    }

    public static IServiceCollection AddServiceInjection(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IPermissionsService, PermissionsService>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }

    public static IServiceCollection AddUseCaseInjection(this IServiceCollection services)
    {
        services.AddScoped<ICreateUser, CreateUser>();
        services.AddScoped<IUpdateUser, UpdateUser>();
        services.AddScoped<IGetAllUser, GetAllUser>();
        services.AddScoped<IGetUserById, GetUserById>();
        services.AddScoped<IDeleteUser, DeleteUser>();
        services.AddScoped<IGetUserByEmailAndPassword, GetUserByEmailAndPassword>();

        services.AddScoped<ICreateProfile, CreateProfile>();
        services.AddScoped<IUpdateProfile, UpdateProfile>();
        services.AddScoped<IGetAllProfile, GetAllProfile>();
        services.AddScoped<IGetProfileById, GetProfileById>();
        services.AddScoped<IDeleteProfile, DeleteProfile>();
        services.AddScoped<IGetAllPermissions, GetAllPermissions>();

        return services;
    }
}
