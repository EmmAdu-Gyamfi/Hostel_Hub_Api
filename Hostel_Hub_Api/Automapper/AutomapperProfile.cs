using AutoMapper;
using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_App.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Hostel, HostelDTO>();

            CreateMap<HostelDTO, Hostel>();

            CreateMap<FileStoreDTO, FileStore>();

            CreateMap<FileStore, FileStoreDTO>();


            CreateMap<HostelPhoto, HostelPhotoDTO>();

            CreateMap<HostelPhotoDTO, HostelPhoto>();


            CreateMap<HostelRating, HostelRatingDTO>();

            CreateMap<HostelRatingDTO, HostelRating>();


            CreateMap<HostelReview, HostelReviewDTO>();

            CreateMap<HostelReviewDTO, HostelReview>();


            CreateMap<HostelRoom, HostelRoomDTO>();

            CreateMap<HostelRoomDTO, HostelRoom>();


            CreateMap<Room, RoomDTO>();

            CreateMap<RoomDTO, Room>();


            CreateMap<RoomPhoto, RoomPhotoDTO>();

            CreateMap<RoomPhotoDTO, RoomPhoto>();

        }
    }
}
