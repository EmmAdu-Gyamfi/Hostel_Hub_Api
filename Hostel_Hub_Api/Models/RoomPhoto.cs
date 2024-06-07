using System;
using System.Collections.Generic;

#nullable disable

namespace Hostel_Hub_Api.Models
{
    public partial class RoomPhoto
    {
        public int RoomPhotosId { get; set; }
        public int RoomId { get; set; }
        public int FileId { get; set; }

        public virtual FileStore File { get; set; }
        public virtual Room Room { get; set; }
    }
}
