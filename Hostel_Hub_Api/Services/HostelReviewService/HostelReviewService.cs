using AutoMapper;
using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Models;
using Hostel_Hub_Api.Repositories.HostelReviewRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelReviewService
{
    public class HostelReviewService : IHostelReviewService
    {
        private readonly IMapper _mapper;

        private readonly IHostelReviewRepository _hostelReviewRepository;

        public HostelReviewService(IMapper mapper, IHostelReviewRepository hostelReviewRepository)
        {
            _mapper = mapper;
            _hostelReviewRepository = hostelReviewRepository;
        }

        public async Task AddHostelReviewAsync(HostelReviewDTO hostelReviewDTO)
        {
            var entity = _mapper.Map<HostelReview>(hostelReviewDTO);

            await _hostelReviewRepository.InsertAsync(entity);

            await _hostelReviewRepository.SaveAsync();
        }

        public async Task EditHostelReviewAsync(HostelReviewDTO hostelReviewDTO)
        {
            var entity = _mapper.Map<HostelReview>(hostelReviewDTO);

             _hostelReviewRepository.Update(entity);

            await _hostelReviewRepository.SaveAsync();
        }
    }
}
