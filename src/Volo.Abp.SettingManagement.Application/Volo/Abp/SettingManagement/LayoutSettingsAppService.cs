using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Emailing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Features;

namespace Volo.Abp.SettingManagement;

[Authorize(SettingManagementPermissions.Layouting)]
public class LayoutSettingsAppService : SettingManagementAppServiceBase, ILayoutSettingsAppService
{
    protected ISettingManager SettingManager { get; }
    
    protected IEmailSender EmailSender { get; }

    public LayoutSettingsAppService(ISettingManager settingManager)
    {
        SettingManager = settingManager;
    }

    public virtual async Task<LayoutSettingsDto> GetAsync()
    {
        await CheckFeatureAsync();

        var settingsDto = new LayoutSettingsDto
        {
            ThemeName = await SettingProvider.GetOrNullAsync(LayoutSettingConsts.ThemeName),
            LogoImage = await SettingProvider.GetOrNullAsync(LayoutSettingConsts.LogoImage)
        };

        if (CurrentTenant.IsAvailable)
        {
            settingsDto.ThemeName = await SettingManager.GetOrNullForTenantAsync(LayoutSettingConsts.ThemeName, CurrentTenant.GetId(), false);
            settingsDto.LogoImage = await SettingManager.GetOrNullForTenantAsync(LayoutSettingConsts.LogoImage, CurrentTenant.GetId(), false);
        }

        return settingsDto;
    }

    public virtual async Task UpdateAsync(UpdateLayoutSettingsDto input)
    {
        await CheckFeatureAsync();

        await SettingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, LayoutSettingConsts.ThemeName, input.ThemeName);
        await SettingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, LayoutSettingConsts.LogoImage, input.LogoImage);
    }

    protected virtual async Task CheckFeatureAsync()
    {
        await FeatureChecker.CheckEnabledAsync(SettingManagementFeatures.Enable);
        if (CurrentTenant.IsAvailable)
        {
            await FeatureChecker.CheckEnabledAsync(SettingManagementFeatures.AllowChangingLayoutSettings);
        }
    }
}
