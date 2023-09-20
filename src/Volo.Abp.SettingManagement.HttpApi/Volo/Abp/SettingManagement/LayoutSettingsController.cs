using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.SettingManagement;

[RemoteService(Name = SettingManagementRemoteServiceConsts.RemoteServiceName)]
[Area(SettingManagementRemoteServiceConsts.ModuleName)]
[Route("api/setting-management/layouting")]
public class LayoutSettingsController : AbpControllerBase, ILayoutSettingsAppService
{
    private readonly ILayoutSettingsAppService _layoutSettingsAppService;

    public LayoutSettingsController(ILayoutSettingsAppService layoutSettingsAppService)
    {
        _layoutSettingsAppService = layoutSettingsAppService;
    }

    [HttpGet]
    public Task<LayoutSettingsDto> GetAsync()
    {
        return _layoutSettingsAppService.GetAsync();
    }

    [HttpPost]
    public Task UpdateAsync(UpdateLayoutSettingsDto input)
    {
        return _layoutSettingsAppService.UpdateAsync(input);
    }
}
