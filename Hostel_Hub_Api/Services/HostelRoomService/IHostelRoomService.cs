using Hostel_Hub_Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelRoomService
{
    public interface IHostelRoomService
    {
        Task AddHostelRoomAsync(RoomDTO roomDTO, int hostelId);

        RoomDTO GetNewlyAddedRoom(string roomCategory, string roomLabel, decimal price);
    }
}
