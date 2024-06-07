using Hostel_Hub_Api.DTO;
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

    public class RoomPhotoController : ControllerBase
    {
        private readonly IRoomPhotoService _roomPhotoService;

        public RoomPhotoController(IRoomPhotoService roomPhotoService)
        {
            _roomPhotoService = roomPhotoService;
        }

        [HttpPost]
        public async Task<ActionResult<RoomPhotoDTO>> AddPhoto([FromBody] RoomPhotoDTO roomPhotoDTO)
        {
            await _roomPhotoService.AddRoomPhotoAsync(roomPhotoDTO);

            return CreatedAtAction("EditHostel", "HostelController", new { id = roomPhotoDTO.RoomId }, roomPhotoDTO);
        }
  

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeletePhoto(int id)
        {
            var roomPhotoDTO = await _roomPhotoService.GetRoomPhotoAsync(id);

            if (roomPhotoDTO == null)
            {
                return NotFound();

            }

            await _roomPhotoService.DeleteRoomPhotoAsync(roomPhotoDTO);

            return NoContent();
        }
    }
}
