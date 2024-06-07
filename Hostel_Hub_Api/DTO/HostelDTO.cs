using Hostel_Hub_Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.DTO
{
    public class HostelDTO
    {
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

        public virtual ICollection<HostelPhotoDTO> HostelPhotos { get; set; }
        public virtual ICollection<HostelRatingDTO> HostelRatings { get; set; }
        public virtual ICollection<HostelReviewDTO> HostelReviews { get; set; }
        public virtual ICollection<HostelRoomDTO> HostelRooms { get; set; }
    }
}
