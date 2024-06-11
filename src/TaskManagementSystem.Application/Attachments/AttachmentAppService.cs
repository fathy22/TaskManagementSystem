using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Attachments
{
    public class AttachmentAppService : ApplicationService, IAttachmentAppService
    {
        private readonly IRepository<Attachment, int> _attachmentRepository;
        public AttachmentAppService(IRepository<Attachment, int> attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task<int> UploadAttachmentAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new UserFriendlyException("File is empty.");
            }
            var postedFileExtension = Path.GetExtension(file.FileName);
            if (postedFileExtension == ".exe" || postedFileExtension == ".dll" || postedFileExtension == ".ps1" || postedFileExtension == ".js")
            {
                throw new Exception("not allowed files");
            }
            var filePath = Path.Combine("wwwroot", "attachments", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var attachment = new Attachment
            {
                StoredFileName = file.FileName,
                ContentType = file.ContentType,
                Name = file.FileName,
                Length = file.Length,
                Extension= postedFileExtension
            };

            await _attachmentRepository.InsertAsync(attachment);
            await CurrentUnitOfWork.SaveChangesAsync();

            return attachment.Id;
        }
    }
}
