using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Services.HostelRatingService;
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
    public class HostelRatingController : ControllerBase
    {
        private readonly IHostelRatingService _hostelRatingService;

        public HostelRatingController(IHostelRatingService hostelRatingService)
        {
            _hostelRatingService = hostelRatingService;
        }

        [HttpPost]

        public async Task<ActionResult<HostelRatingDTO>> AddReview([FromBody] HostelRatingDTO hostelRatingDTO)
        {
            await _hostelRatingService.AddHostelRatingAsync(hostelRatingDTO);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditReview(int id, [FromBody] HostelRatingDTO hostelRatingDTO)
        {
            if (id != hostelRatingDTO.HostelId)
            {
                return BadRequest();
            }

            await _hostelRatingService.AddHostelRatingAsync(hostelRatingDTO);

            return NoContent();
        }
    }
}
