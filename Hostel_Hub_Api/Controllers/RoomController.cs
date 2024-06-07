using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Services.HostelService;
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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]

        public ActionResult<List<RoomPhotoDTO>> GetRoomPhotos(int? roomId)
        {
            if (roomId == null)
            {
                return NotFound();
            }
            return _roomService.GetRoomPhotos((int)roomId);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<RoomDTO>> GetRoom(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var roomDTO = await _roomService.GetRoomAsync((int)id);

            return roomDTO;
        }

        [HttpPost]

        public async Task<ActionResult> AddRoom([FromBody] RoomDTO roomDTO)
        {
            var id = await _roomService.AddRoomAsync(roomDTO);

            return Ok(id);

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteRoom(int id)
        {
            var roomDTO = await _roomService.GetRoomAsync(id);

            if(roomDTO == null)
            {
                return NotFound();
            }

            await _roomService.DeleteRoomAsync(roomDTO);

            return NoContent();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> EditRoom(int id, [FromBody] RoomDTO roomDTO)
        {
            if(id != roomDTO.RoomId)
            {
                return BadRequest();
            }

            await _roomService.EditRoomAsync(roomDTO);

            return NoContent();
        }

    }
}
