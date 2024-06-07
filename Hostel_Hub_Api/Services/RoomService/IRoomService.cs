using Hostel_Hub_Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelService
{
    public interface IRoomService
    {
        List<RoomPhotoDTO> GetRoomPhotos(int roomId);

        Task<RoomDTO> GetRoomAsync(int roomId);

        Task<int> AddRoomAsync(RoomDTO roomDTO);

        Task DeleteRoomAsync(RoomDTO roomDTO);

        Task EditRoomAsync(RoomDTO roomDTO); 
    }
}
