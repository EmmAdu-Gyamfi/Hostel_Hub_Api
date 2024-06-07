using System;
using System.Collections.Generic;

#nullable disable

namespace Hostel_Hub_Api.Models
{
    public partial class HostelReview
    {
        public int HostelReviewId { get; set; }
        public string Comment { get; set; }
        public int HostelId { get; set; }

        public virtual Hostel Hostel { get; set; }
    }
}
