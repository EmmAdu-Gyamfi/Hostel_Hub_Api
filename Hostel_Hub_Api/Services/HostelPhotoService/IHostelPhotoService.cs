using Hostel_Hub_Api.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.HostelService
{
    public interface IHostelPhotoService
    {
        Task AddHostelPhotoAsync(IFormFile file, int hostelId);

        Task DeleteHostelPhotoAsync(HostelPhotoDTO hostelPhotoDTO);

        List<int> GetHostelImageFileIds(int hostelId);

        Task<byte[]> GetPhotoAsync(int fileId);


        Task<FileStoreDTO> GetHostelPhotoAsync(int fileId);
    }
}
