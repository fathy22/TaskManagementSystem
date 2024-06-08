using Abp.Application.Services.Dto;

namespace TaskManagementSystem.Tasks.Dto
{
    public class PagedTaskSheetResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

