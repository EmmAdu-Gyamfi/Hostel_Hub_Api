using System;
using System.Collections.Generic;

#nullable disable

namespace Hostel_Hub_Api.Models
{
    public partial class Room
    {
        public Room()
        {
            HostelRooms = new HashSet<HostelRoom>();
            RoomPhotos = new HashSet<RoomPhoto>();
        }

        public int RoomId { get; set; }
        public string RoomCategory { get; set; }
        public string RoomLabel { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<HostelRoom> HostelRooms { get; set; }
        public virtual ICollection<RoomPhoto> RoomPhotos { get; set; }
    }
}
