using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace CSP.Auth.SettingManagement
{
    public class LayoutSettingProvider: SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(LayoutSettingConsts.ThemeName, "ThemeName 1"),
                new SettingDefinition(LayoutSettingConsts.LogoImage, "LogoImage 1")
            );
        }
    }
}
