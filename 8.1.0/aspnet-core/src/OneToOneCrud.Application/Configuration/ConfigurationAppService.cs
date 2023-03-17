using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using OneToOneCrud.Configuration.Dto;

namespace OneToOneCrud.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : OneToOneCrudAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
