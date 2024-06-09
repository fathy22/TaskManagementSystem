using Abp.Application.Services.Dto;

namespace TaskManagementSystem.Tasks.Dto
{
    public class PagedTaskSheetResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public long? UserId { get; set; }
        public long? TeamId { get; set; }
    }
}

