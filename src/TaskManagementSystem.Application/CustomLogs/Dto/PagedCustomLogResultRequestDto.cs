using Abp.Application.Services.Dto;

namespace TaskManagementSystem.CustomLogs.Dto
{
    public class PagedCustomLogResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

