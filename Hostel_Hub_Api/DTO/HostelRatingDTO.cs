using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.DTO
{
    public class HostelRatingDTO
    {
        public int HostelRatingId { get; set; }
        public decimal RatingValue { get; set; }
        public int HostelId { get; set; }

        public virtual HostelDTO Hostel { get; set; }
    }
}
