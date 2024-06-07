using System;
using System.Collections.Generic;

#nullable disable

namespace Hostel_Hub_Api.Models
{
    public partial class HostelRating
    {
        public int HostelRatingId { get; set; }
        public decimal RatingValue { get; set; }
        public int HostelId { get; set; }

        public virtual Hostel Hostel { get; set; }
    }
}
