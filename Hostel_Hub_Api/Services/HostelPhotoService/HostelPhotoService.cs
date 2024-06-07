using AutoMapper;
using Hostel_Hub_Api.DTO;
using Hostel_Hub_Api.Models;
using Hostel_Hub_Api.Repositories.HostelPhotoRepository;
using Hostel_Hub_Api.Services.FileStoreService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelService
{
    public class HostelPhotoService : IHostelPhotoService
    {
        private readonly IHostelPhotoRepository _hostelPhotoRepository;

        private readonly IFileStoreService _fileStoreService;

        private readonly IMapper _mapper;

        public HostelPhotoService(IHostelPhotoRepository hostelPhotoRepository, IMapper mapper, IFileStoreService fileStoreService)
        {
            _hostelPhotoRepository = hostelPhotoRepository;
            _mapper = mapper;
            _fileStoreService = fileStoreService;
        }

        //public async Task AddHostelPhotoAsync(HostelPhotoDTO hostelPhotoDTO)
        //{
        //    var entity = _mapper.Map<HostelPhoto>(hostelPhotoDTO);

        //    await _hostelPhotoRepository.InsertAsync(entity);

        //    await _hostelPhotoRepository.SaveAsync();
        //}

        public async Task DeleteHostelPhotoAsync(HostelPhotoDTO hostelPhotoDTO)
        {
            var entity = _mapper.Map<HostelPhoto>(hostelPhotoDTO);

             _hostelPhotoRepository.Delete(entity);

            await _hostelPhotoRepository.SaveAsync();



        }

        public List<int> GetHostelImageFileIds(int hostelId)
        {
            var query = _hostelPhotoRepository.Query();

            var hostelPhotoIds = query.Where(a => a.HostelId == hostelId).Select(a => a.FileId).ToList();

            //List<FileStoreDTO> hostelDTOs = new List<FileStoreDTO>();

            //foreach (var fileId in hostelPhotoIds)
            //{
            //    var hostelDTO = await _fileStoreService.GetFileAsync(fileId);

            //    hostelDTOs.Add(hostelDTO);
            //}

            //var hostelDTOs =  hostelPhotoIds.Select( a => _fileStoreService.GetFileAsync(a)).ToList();

            return hostelPhotoIds;
        }

        public async Task<FileStoreDTO> GetHostelPhotoAsync(int fileId)
        {
            var entity = await _hostelPhotoRepository.GetAsync(fileId);

            var fileStoreDTO = _mapper.Map<FileStoreDTO>(entity);

            return fileStoreDTO;
        }



        public async Task AddHostelPhotoAsync(IFormFile file, int hostelId)
        {
            var fileName = file.FileName;
            long length = file.Length;
           var mimeType = file.ContentType;
            var fileStore = new FileStoreDTO
            {
                FileSize = (int)length,
                FileName = fileName,
                MimeType = mimeType,
                Description = "beans"
            };
            if (length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    fileStore.FileData = fileBytes;
                     //string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                }
            }

           
            var fileId = await _fileStoreService.AddFileAsync(fileStore);
           

            var hostelPhoto = new HostelPhoto
            {
                FileId = fileId,
                HostelId = hostelId
            };

            await _hostelPhotoRepository.InsertAsync(hostelPhoto);
            await _hostelPhotoRepository.SaveAsync();
        }

        public async Task<byte[]> GetPhotoAsync(int fileId)
        {
            var file = await _fileStoreService.GetFileAsync(fileId);

            var imageByte = file.FileData;
            return imageByte;
        }
    }
}
