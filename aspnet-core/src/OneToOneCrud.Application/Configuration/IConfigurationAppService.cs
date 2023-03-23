using System.Threading.Tasks;
using OneToOneCrud.Configuration.Dto;

namespace OneToOneCrud.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
