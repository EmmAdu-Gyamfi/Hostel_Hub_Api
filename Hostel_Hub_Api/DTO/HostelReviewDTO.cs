using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.DTO
{
    public class HostelReviewDTO
    {
        public int HostelReviewId { get; set; }
        public string Comment { get; set; }
        public int HostelId { get; set; }

        public virtual HostelDTO Hostel { get; set; }
    }
}
