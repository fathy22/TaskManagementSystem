using System.Threading.Tasks;
using TaskManagementSystem.Configuration.Dto;

namespace TaskManagementSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
