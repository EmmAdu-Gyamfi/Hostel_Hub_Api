using System;
using System.Collections.Generic;

#nullable disable

namespace Hostel_Hub_Api.Models
{
    public partial class HostelRoom
    {
        public int HostelRoomId { get; set; }
        public int? HostelId { get; set; }
        public int RoomId { get; set; }

        public virtual Hostel Hostel { get; set; }
        public virtual Room Room { get; set; }
    }
}
