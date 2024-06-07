using Hostel_Hub_Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelService
{
   public interface IRoomPhotoService
    {
        Task AddRoomPhotoAsync(RoomPhotoDTO roomPhotoDTO);

        Task DeleteRoomPhotoAsync(RoomPhotoDTO roomPhotoDTO);

        Task<RoomPhotoDTO> GetRoomPhotoAsync(int id);

    }
}
