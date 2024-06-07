using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Services.FileStoreService;
using Hostel_Hub_Api.Services.HostelRoomService;
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
    public class HostelRoomController : ControllerBase
    {
        private readonly IHostelRoomService _hostelRoomService;

        private readonly IFileStoreService _fileStoreService;

        public HostelRoomController(IHostelRoomService hostelRoomService, IFileStoreService fileStoreService)
        {
            _hostelRoomService = hostelRoomService;
            _fileStoreService = fileStoreService;
        }

        [HttpPost("{hostelId}/AddRoom")]
        public async Task<ActionResult> AddRoom(int hostelId, [FromBody] RoomDTO roomDTO)
         {
            await _hostelRoomService.AddHostelRoomAsync(roomDTO, hostelId);

            var newRoom = _hostelRoomService.GetNewlyAddedRoom(roomDTO.RoomCategory, roomDTO.RoomLabel, roomDTO.Price);
            return Ok(newRoom);
            //var pictureUrl = _fileStoreService.GetFileUrl(fileId);
            //return await GetHostelImagesAsync(hostelId);
        }
    }
}
