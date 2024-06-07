using AutoMapper;
using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Models;
using Hostel_Hub_Api.Repositories.RoomPhotoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelService
{
    public class RoomPhotoService : IRoomPhotoService
    {
        private readonly IRoomPhotoRepository _roomPhotoRepository;

        private readonly IMapper _mapper;

        public RoomPhotoService(IRoomPhotoRepository roomPhotoRepository, IMapper mapper)
        {
            _roomPhotoRepository = roomPhotoRepository;
            _mapper = mapper;
        }

        public async Task AddRoomPhotoAsync(RoomPhotoDTO roomPhotoDTO)
        {
            var entity = _mapper.Map<RoomPhoto>(roomPhotoDTO);

            await _roomPhotoRepository.InsertAsync(entity);

            await _roomPhotoRepository.SaveAsync();
        }


        public async Task DeleteRoomPhotoAsync(RoomPhotoDTO roomPhotoDTO)
        {
            var entity = _mapper.Map<RoomPhoto>(roomPhotoDTO);

             _roomPhotoRepository.Delete(entity);

            await _roomPhotoRepository.SaveAsync();
        }

        public async Task<RoomPhotoDTO> GetRoomPhotoAsync(int id)
        {
            var entity = await _roomPhotoRepository.GetAsync(id);

            var roomPhotoDTO = _mapper.Map<RoomPhotoDTO>(entity);

            return roomPhotoDTO;
        }
    }
}
