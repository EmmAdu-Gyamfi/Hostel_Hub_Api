using System;
using System.Collections.Generic;

#nullable disable

namespace Hostel_Hub_Api.Models
{
    public partial class HostelPhoto
    {
        public int HostelPhotoId { get; set; }
        public int HostelId { get; set; }
        public int FileId { get; set; }

        public virtual FileStore File { get; set; }
        public virtual Hostel Hostel { get; set; }
    }
}
