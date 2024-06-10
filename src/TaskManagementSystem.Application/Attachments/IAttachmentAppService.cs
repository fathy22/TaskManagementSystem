using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Attachments
{
    public interface IAttachmentAppService
    {
        Task<string> UploadAttachmentAsync(IFormFile file);
    }
}
