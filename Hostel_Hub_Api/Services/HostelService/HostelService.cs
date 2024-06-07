using AutoMapper;
using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Models;
using Hostel_Hub_Api.Repositories.HostelPhotoRepository;
using Hostel_Hub_Api.Repositories.HostelRatingRepository;
using Hostel_Hub_Api.Repositories.HostelRepository;
using Hostel_Hub_Api.Repositories.HostelReviewRepository;
using Hostel_Hub_Api.Repositories.HostelRoomRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelService
{
    public class HostelService : IHostelService
    {
        private readonly IHostelRepository _hostelRepository;

        private readonly IHostelPhotoRepository _hostelPhotoRepository;

        private readonly IHostelRatingRepository _hostelRatingRepository;

        private readonly IHostelReviewRepository _hostelReviewRepository;

        private readonly IHostelRoomRepository _hostelRoomRepository;

        private readonly IMapper _mapper;

      

        public HostelService(
            IHostelRepository hostelRepository,
            IMapper mapper,
            IHostelPhotoRepository hostelPhotoRepository,
            IHostelRatingRepository hostelRatingRepository,
            IHostelReviewRepository hostelReviewRepository, IHostelRoomRepository hostelRoomRepository)
        {
            _hostelRepository = hostelRepository;

            _mapper = mapper;

            _hostelPhotoRepository = hostelPhotoRepository;

            _hostelRatingRepository = hostelRatingRepository;

            _hostelReviewRepository = hostelReviewRepository;

            _hostelRoomRepository = hostelRoomRepository;
        }

        public async Task AddHostelAsync(HostelDTO hostelDTO)
        {

            var hostel = _mapper.Map<Hostel>(hostelDTO);

            await _hostelRepository.InsertAsync(hostel);

            await _hostelRepository.SaveAsync();

        }

        public async Task DeleteHostelAsync(HostelDTO hostelDTO)
        {
           
            var hostel = _mapper.Map<Hostel>(hostelDTO);

            _hostelRepository.Delete(hostel);

            await _hostelRepository.SaveAsync();

        }

        public async Task EditHostelAsync(HostelDTO hostelDTO)
        {
            var hostel = _mapper.Map<Hostel>(hostelDTO);

            _hostelRepository.Update(hostel);

            await _hostelRepository.SaveAsync();


        }

        public async Task<List<HostelDTO>> GetAllHostelsAsync()
        {
            var entities = await _hostelRepository.GetAllAsync();

            var hostelDTOs = entities.Select(a => _mapper.Map<HostelDTO>(a)).ToList();

            return hostelDTOs;
        }

        public async Task<HostelDTO> GetHostelAsync(int hostelId)
        {
            var entity = await _hostelRepository.GetAsync(hostelId);

            var hostelDTO = _mapper.Map<HostelDTO>(entity);


            return hostelDTO;


        }

      

        public List<HostelRatingDTO> GetHostelRatings(int hostelId)
        {
            var query = _hostelRatingRepository.Query();

            var entities = query.Select(a => a).Where(a => a.HostelId == hostelId).ToList();

            var hostelDTOs = entities.Select(a => _mapper.Map<HostelRatingDTO>(a)).ToList();

            return hostelDTOs;

        }

        public List<HostelReviewDTO> GetHostelReviews(int hostelId)
        {
            var query = _hostelReviewRepository.Query();

            var entities = query.Select(a => a).Where(a => a.HostelId == hostelId).ToList();

            var hostelDTOs = entities.Select(a => _mapper.Map<HostelReviewDTO>(a)).ToList();

            return hostelDTOs;
        }

        public List<HostelRoomDTO> GetHostelRooms(int hostelId)
        {
            var query = _hostelRoomRepository.Query();

            var entities = query.Select(a => a).Where(a => a.HostelId == hostelId).ToList();

            var hostelDTOs = entities.Select(a => _mapper.Map<HostelRoomDTO>(a)).ToList();

            return hostelDTOs;
        }

        public HostelDTO GetNewlyCreatedHostel(string name, string locality, string address)
        {
            var query = _hostelRepository.Query();

            var entity = query.Where(a => a.Name == name && a.Locality == locality && a.Address == address).Select(k => k).FirstOrDefault();

            var hostelDTO = _mapper.Map<HostelDTO>(entity);

            return hostelDTO;
        }
    }
}
