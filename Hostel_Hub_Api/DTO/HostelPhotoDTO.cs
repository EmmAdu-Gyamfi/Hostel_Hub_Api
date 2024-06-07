using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.DTO
{
    public class HostelPhotoDTO
    {
        public int HostelPhotoId { get; set; }
        public int HostelId { get; set; }
        public int FileId { get; set; }

        public virtual FileStoreDTO File { get; set; }
        public virtual HostelDTO Hostel { get; set; }
    }
}
