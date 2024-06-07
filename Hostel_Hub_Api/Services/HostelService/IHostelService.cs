using Hostel_Hub_Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelService
{
    public interface IHostelService
    {
        Task<List<HostelDTO>> GetAllHostelsAsync();

        Task<HostelDTO> GetHostelAsync(int hostelId);

        Task AddHostelAsync(HostelDTO hostelDTO);

        Task DeleteHostelAsync(HostelDTO hostelDTO);

        Task EditHostelAsync(HostelDTO hostelDTO);


        List<HostelRatingDTO> GetHostelRatings(int hostelId);

        List<HostelReviewDTO> GetHostelReviews(int hostelId);

        HostelDTO GetNewlyCreatedHostel(string name, string locality, string address);

        List<HostelRoomDTO> GetHostelRooms(int hostelId);
    }
}
