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
    public class HostelController : ControllerBase
    {
        private readonly IHostelService _hostelService;

        public HostelController(IHostelService hostelService)
        {
            _hostelService = hostelService;
        }

        [HttpGet]

        public async Task<ActionResult<List<HostelDTO>>> GetAllHostels()
        {
            return await _hostelService.GetAllHostelsAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<HostelDTO>> GetHostel(int? id)
        {
            var hostel =  await _hostelService.GetHostelAsync((int)id);

            if (hostel == null)
            {
                return NotFound();
            }

            return hostel;
        }

        [HttpGet("{id}")]

        public ActionResult<List<HostelRatingDTO>> GetRatings(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return _hostelService.GetHostelRatings((int)id);
        }

        [HttpGet("{id}")]

        public ActionResult<List<HostelReviewDTO>> GetReviews(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return _hostelService.GetHostelReviews((int)id);
        }

        [HttpGet("{id}")]

        public ActionResult<List<HostelRoomDTO>> GetRooms(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return _hostelService.GetHostelRooms((int)id);
        }

        [HttpPost]

        public async Task<ActionResult<HostelDTO>> AddHostel([FromBody] HostelDTO hostelDTO)
        {
            await  _hostelService.AddHostelAsync(hostelDTO);

            //return CreatedAtAction("EditHostel", new { id = hostelDTO.HostelId }, hostelDTO);
           var newHostel = _hostelService.GetNewlyCreatedHostel(hostelDTO.Name, hostelDTO.Locality, hostelDTO.Address);

            return Ok(newHostel);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditHostel(int id, [FromBody] HostelDTO hostelDTO)
        {
            if(id != hostelDTO.HostelId)
            {
                return BadRequest();
            }

            await _hostelService.EditHostelAsync(hostelDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteHostel(int id)
        {
            var hostelDTO = await _hostelService.GetHostelAsync(id);

            if(hostelDTO == null)
            {
                return NotFound();
            }

            await _hostelService.DeleteHostelAsync(hostelDTO);

            return NoContent();

        }

    }
}
