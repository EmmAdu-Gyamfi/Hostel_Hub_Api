using AutoMapper;
using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Models;
using Hostel_Hub_Api.Repositories.HostelRoomRepository;
using Hostel_Hub_Api.Repositories.RoomRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelRoomService
{
    public class HostelRoomService : IHostelRoomService
    {
        private readonly IHostelRoomRepository _hostelRoomRepository;

        private readonly IRoomRepository _roomRepository;

        private readonly IMapper _mapper;

        public HostelRoomService(IHostelRoomRepository hostelRoomRepository, IRoomRepository roomRepository, IMapper mapper)
        {
            _hostelRoomRepository = hostelRoomRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task AddHostelRoomAsync(RoomDTO roomDTO, int hostelId)
        {
            var entity = _mapper.Map<Room>(roomDTO);

            await _roomRepository.InsertAsync(entity);

            await _roomRepository.SaveAsync();

            var roomId = entity.RoomId;

            var hostelRoom = new HostelRoom
            {
                HostelId = hostelId,
                RoomId = roomId
            };

            await _hostelRoomRepository.InsertAsync(hostelRoom);

            await _hostelRoomRepository.SaveAsync();
        }

        public RoomDTO GetNewlyAddedRoom(string roomCategory, string roomLabel, decimal price)
        {
            var query = _roomRepository.Query();

            var entity = query.Where(a => a.RoomCategory == roomCategory && a.RoomLabel == roomLabel && a.Price == price).Select(k => k).FirstOrDefault();

            var roomDTO = _mapper.Map<RoomDTO>(entity);

            return roomDTO;
        }
    }
}
