using Abp.Application.Services.Dto;

namespace OneToOneCrud.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

