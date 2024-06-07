using AutoMapper;
using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Models;
using Hostel_Hub_Api.Repositories.HostelRatingRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelRatingService
{
    public class HostelRatingService : IHostelRatingService
    {
        private readonly IHostelRatingRepository _hostelRatingRepository;

        private readonly IMapper _mapper;

        public HostelRatingService(IHostelRatingRepository hostelRatingRepository, IMapper mapper)
        {
            _hostelRatingRepository = hostelRatingRepository;
            _mapper = mapper;
        }

        public async Task AddHostelRatingAsync(HostelRatingDTO hostelRatingDTO)
        {
            var entity = _mapper.Map<HostelRating>(hostelRatingDTO);

            await _hostelRatingRepository.InsertAsync(entity);

            await _hostelRatingRepository.SaveAsync();
        }

        public async Task EditHostelRatingAsync(HostelRatingDTO hostelRatingDTO)
        {
            var entity = _mapper.Map<HostelRating>(hostelRatingDTO);

            _hostelRatingRepository.Delete(entity);

            await _hostelRatingRepository.SaveAsync();
        }
    }
}
