using AutoMapper;
using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Models;
using Hostel_Hub_Api.Repositories.FileStoreRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.FileStoreService
{
    public class FileStoreService : IFileStoreService
    {
        private readonly IFileStoreRepository _fileStoreRepository;

        private readonly IMapper _mapper;

        public FileStoreService(IFileStoreRepository fileStoreRepository, IMapper mapper)
        {
            _fileStoreRepository = fileStoreRepository;
            _mapper = mapper;
        }

        public async Task<int> AddFileAsync(FileStoreDTO filestore)
        {
           var entity =  _mapper.Map<FileStore>(filestore);

           await _fileStoreRepository.InsertAsync(entity);

            await _fileStoreRepository.SaveAsync();

            int fileId = entity.FileId;
            return fileId;

          
        }

        public async Task<FileStoreDTO> GetFileAsync(int fileId)
        {
            var entity = await _fileStoreRepository.GetAsync(fileId);

            var dto = _mapper.Map<FileStoreDTO>(entity);

            return dto;
        }

        public async Task<List<FileStoreDTO>> GetFilesAsync(List<int> fileIds)
        {
            var entities = await _fileStoreRepository.Query().Where(a => fileIds.Contains(a.FileId))
                .Select(p => new FileStore 
                { 
                    FileId = p.FileId,
                    Description = p.Description,
                    FileName = p.FileName,
                    FileSize = p.FileSize,
                    MimeType = p.MimeType
                }).ToListAsync();

            var dtos = _mapper.Map<List<FileStoreDTO>>(entities);

            return dtos;
        }
    }
}
