﻿using TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Infra.Data.EF.Repositories;
public class ProfilesSubMenusRepository
    : GenericRepository<ProfilesSubMenus>, IProfilesSubMenusRepository
{
    public ProfilesSubMenusRepository(TemplateDotNetDbContext context)
        : base(context)
    {
    }

    public void RemoveRange(List<ProfilesSubMenus> profilesSubMenus)
    {
        _dbSet.RemoveRange(profilesSubMenus);
    }
}
