using AutoMapper;
using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Models;
using Hostel_Hub_Api.Repositories.RoomPhotoRepository;
using Hostel_Hub_Api.Repositories.RoomRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelService
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        private readonly IRoomPhotoRepository _roomPhotoRepository;

        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IRoomPhotoRepository roomPhotoRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _roomPhotoRepository = roomPhotoRepository;
            _mapper = mapper;
        }

        public async Task<int> AddRoomAsync(RoomDTO roomDTO)
        {
            var entity = _mapper.Map<Room>(roomDTO);

            await _roomRepository.InsertAsync(entity);

            await _roomRepository.SaveAsync();

            var roomId = entity.RoomId;

            return roomId;


        }

        public async Task DeleteRoomAsync(RoomDTO roomDTO)
        {
            var entity = _mapper.Map<Room>(roomDTO);

            _roomRepository.Delete(entity);

            await _roomRepository.SaveAsync();
        }

        public async Task EditRoomAsync(RoomDTO roomDTO)
        {
            var entity = _mapper.Map<Room>(roomDTO);

            _roomRepository.Update(entity);

            await _roomRepository.SaveAsync();
        }

        public async Task<RoomDTO> GetRoomAsync(int roomId)
        {
            var entity = await _roomRepository.GetAsync(roomId);

            var roomDTO = _mapper.Map<RoomDTO>(entity);

            return roomDTO;
        }

        public List<RoomPhotoDTO> GetRoomPhotos(int roomId)
        {
            var query = _roomPhotoRepository.Query();

            var entities = query.Select(a => a).Where(a => a.RoomId == roomId).ToList();

            var roomPhotoDTOs = entities.Select(a => _mapper.Map<RoomPhotoDTO>(a)).ToList();

            return roomPhotoDTOs;
        }
    }
}
