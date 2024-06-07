using System;
using System.Collections.Generic;

#nullable disable

namespace Hostel_Hub_Api.Models
{
    public partial class Hostel
    {
        public Hostel()
        {
            HostelPhotos = new HashSet<HostelPhoto>();
            HostelRatings = new HashSet<HostelRating>();
            HostelReviews = new HashSet<HostelReview>();
            HostelRooms = new HashSet<HostelRoom>();
        }

        public int HostelId { get; set; }
        public string Name { get; set; }
        public string Locality { get; set; }
        public string Address { get; set; }
        public string Condition { get; set; }
        public string Furnishing { get; set; }
        public int MinimumRentTime { get; set; }
        public bool Negotiation { get; set; }
        public string PriceRange { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<HostelPhoto> HostelPhotos { get; set; }
        public virtual ICollection<HostelRating> HostelRatings { get; set; }
        public virtual ICollection<HostelReview> HostelReviews { get; set; }
        public virtual ICollection<HostelRoom> HostelRooms { get; set; }
    }
}
