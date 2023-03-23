using Abp.Application.Services;
using OneToOneCrud.MultiTenancy.Dto;

namespace OneToOneCrud.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

