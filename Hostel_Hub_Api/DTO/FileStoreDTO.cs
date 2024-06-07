using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.DTO
{
    public class FileStoreDTO
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public byte[] FileData { get; set; }
        public int FileSize { get; set; }
        public string MimeType { get; set; }

        //public virtual ICollection<HostelPhotoDTO> HostelPhotos { get; set; }
        //public virtual ICollection<RoomPhotoDTO> RoomPhotos { get; set; }
    }
}
