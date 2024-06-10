using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagementSystem.Attachments;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    public class AttachmentController : Controller
    {
        private readonly IAttachmentAppService _attachmentAppService;

        public AttachmentController(IAttachmentAppService attachmentAppService)
        {
            _attachmentAppService = attachmentAppService;
        }

        [HttpPost]
        [Route("UploadAttachment")]
        public async Task<IActionResult> UploadAttachment(IFormFile file)
        {
            var result = await _attachmentAppService.UploadAttachmentAsync(file);
            return Ok(result);
        }
    }
}
