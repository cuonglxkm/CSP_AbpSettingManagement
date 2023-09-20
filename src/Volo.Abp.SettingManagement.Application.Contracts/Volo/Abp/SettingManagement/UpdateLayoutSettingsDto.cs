using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Volo.Abp.SettingManagement;
public class UpdateLayoutSettingsDto
{
    public string ThemeName { get; set; }

    public string LogoImage { get; set; }
}
