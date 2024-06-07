using Hostel_Hub_Api.Services.FileStoreService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileStoreController : ControllerBase
    {
        private readonly IFileStoreService _fileStoreService;

        public FileStoreController(IFileStoreService fileService)
        {
            this._fileStoreService = fileService;
        }

        [HttpGet("{fileId}")]
        public async Task<FileResult> GetHostelPhotos(int fileId)
        {
            var file = await _fileStoreService.GetFileAsync(fileId);
            if (file == null)
            {
                throw new CustomException("error");
            }

            return File(file.FileData, file.MimeType);
        }
    }
}
