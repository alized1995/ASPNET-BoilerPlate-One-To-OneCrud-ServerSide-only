using System.Threading.Tasks;
using Abp.Application.Services;
using OneToOneCrud.Authorization.Accounts.Dto;

namespace OneToOneCrud.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
