using Hostel_Hub_Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelReviewService
{
    public interface IHostelReviewService
    {
        Task AddHostelReviewAsync(HostelReviewDTO hostelReviewDTO);

        Task EditHostelReviewAsync(HostelReviewDTO hostelReviewDTO);

    }
}
