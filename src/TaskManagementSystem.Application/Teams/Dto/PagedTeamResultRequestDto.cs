﻿using Abp.Application.Services.Dto;

namespace TaskManagementSystem.Teams.Dto
{
    public class PagedTeamResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

