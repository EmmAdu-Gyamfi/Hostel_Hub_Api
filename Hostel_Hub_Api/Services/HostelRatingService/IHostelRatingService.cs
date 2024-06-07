using Hostel_Hub_Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelRatingService
{
    public interface IHostelRatingService
    {
        Task AddHostelRatingAsync(HostelRatingDTO hostelRatingDTO);

        Task EditHostelRatingAsync(HostelRatingDTO hostelRatingDTO);

    }
}
