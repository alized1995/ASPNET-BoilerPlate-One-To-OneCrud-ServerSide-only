using System.Threading.Tasks;
using Abp.Application.Services;
using OneToOneCrud.Sessions.Dto;

namespace OneToOneCrud.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
