using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.DTO
{
    public class RoomDTO
    {
        public int RoomId { get; set; }
        public string RoomCategory { get; set; }
        public string RoomLabel { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<HostelRoomDTO> HostelRooms { get; set; }
        public virtual ICollection<RoomPhotoDTO> RoomPhotos { get; set; }
    }
}
