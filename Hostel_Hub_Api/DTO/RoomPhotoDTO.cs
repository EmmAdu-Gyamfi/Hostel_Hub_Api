using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.DTO
{
    public class RoomPhotoDTO
    {
        public int RoomPhotosId { get; set; }
        public int RoomId { get; set; }
        public int FileId { get; set; }

        public virtual FileStoreDTO File { get; set; }
        public virtual RoomDTO Room { get; set; }
    }
}
