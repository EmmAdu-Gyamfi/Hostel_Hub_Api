using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Services.HostelReviewService;
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
    public class HostelReviewController : ControllerBase
    {
        private readonly IHostelReviewService _hostelReviewService;

        public HostelReviewController(IHostelReviewService hostelReviewService)
        {
            _hostelReviewService = hostelReviewService;
        }

        [HttpPost]

        public async Task<ActionResult<HostelReviewDTO>> AddReview([FromBody] HostelReviewDTO hostelReviewDTO)
        {
            await _hostelReviewService.AddHostelReviewAsync(hostelReviewDTO);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditReview(int id, [FromBody] HostelReviewDTO hostelReviewDTO)
        {
            if(id != hostelReviewDTO.HostelId)
            {
                return BadRequest();
            }

            await _hostelReviewService.EditHostelReviewAsync(hostelReviewDTO);

            return NoContent();
        }
    }
}
