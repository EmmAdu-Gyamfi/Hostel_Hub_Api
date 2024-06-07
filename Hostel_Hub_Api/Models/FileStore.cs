using System;
using System.Collections.Generic;

#nullable disable

namespace Hostel_Hub_Api.Models
{
    public partial class FileStore
    {
        public FileStore()
        {
            HostelPhotos = new HashSet<HostelPhoto>();
            RoomPhotos = new HashSet<RoomPhoto>();
        }

        public int FileId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public byte[] FileData { get; set; }
        public int FileSize { get; set; }
        public string MimeType { get; set; }

        public virtual ICollection<HostelPhoto> HostelPhotos { get; set; }
        public virtual ICollection<RoomPhoto> RoomPhotos { get; set; }
    }
}
