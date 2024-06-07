using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.DTO
{
    public class HostelRoomDTO
    {
        public int HostelRoomId { get; set; }
        public int? HostelId { get; set; }
        public int RoomId { get; set; }

        public virtual HostelDTO Hostel { get; set; }
        public virtual RoomDTO Room { get; set; }
    }
}
