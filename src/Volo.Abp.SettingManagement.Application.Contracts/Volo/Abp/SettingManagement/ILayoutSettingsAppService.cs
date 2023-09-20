using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Volo.Abp.SettingManagement;

public interface ILayoutSettingsAppService : IApplicationService
{
    Task<LayoutSettingsDto> GetAsync();

    Task UpdateAsync(UpdateLayoutSettingsDto input);

}
