using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Services.FileStoreService;
using Hostel_Hub_Api.Services.HostelService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelPhotoController : ControllerBase
    {
        private readonly IHostelPhotoService _hostelPhotoService;

        private readonly IFileStoreService _fileStoreService;

        public HostelPhotoController(IHostelPhotoService hostelPhotoService, IFileStoreService fileStoreService)
        {
            _hostelPhotoService = hostelPhotoService;
            _fileStoreService = fileStoreService;
        }

        //[HttpPost]
        //public async Task<ActionResult<HostelPhotoDTO>> AddPhoto([FromBody] HostelPhotoDTO hostelPhotoDTO)
        //{
        //    await _hostelPhotoService.AddHostelPhotoAsync(hostelPhotoDTO);

        //    return CreatedAtAction("EditHostel", "HostelController", new { id = hostelPhotoDTO.HostelId }, hostelPhotoDTO);
        //}


        [HttpPost("{hostelId}/AddPhoto")]
        public async Task<ActionResult<List<FileStoreDTO>>> AddPhoto(int hostelId, IFormFile file)
        {
            await _hostelPhotoService.AddHostelPhotoAsync(file, hostelId);
            //var pictureUrl = _fileStoreService.GetFileUrl(fileId);
            return await GetHostelImagesAsync(hostelId);
        }

        [HttpGet("{hostelId}/HostelImages")]
        public async Task<ActionResult<List<FileStoreDTO>>> GetHostelImagesAsync(int hostelId)
        {
            var hostelImageFileIds =  _hostelPhotoService.GetHostelImageFileIds(hostelId);

            var files = await _fileStoreService.GetFilesAsync(hostelImageFileIds);

            return Ok(files);
            
        }

        [HttpGet("{fileId}/GetPhoto")]

        public async Task<ActionResult<byte[]>> GetPhotoAsync(int fileId)
        {
            var photo = await _hostelPhotoService.GetPhotoAsync(fileId);

            return photo;

        }
        //[HttpDelete("{id}")]

        //public async Task<ActionResult> DeletePhoto(int id)
        //{
        //    var hostelPhotoDTO = await _hostelPhotoService.GetHostelPhotoAsync(id);

        //    if(hostelPhotoDTO == null)
        //    {
        //        return NotFound();

        //    }

        //    await _hostelPhotoService.DeleteHostelPhotoAsync(hostelPhotoDTO);

        //    return NoContent();
        //}
    }
}
