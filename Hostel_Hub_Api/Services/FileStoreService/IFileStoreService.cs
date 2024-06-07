using Hostel_Hub_Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Services.FileStoreService
{
    public interface IFileStoreService
    {
        Task<FileStoreDTO> GetFileAsync(int fileId);

        Task<List<FileStoreDTO>> GetFilesAsync(List<int> fileIds);

        Task<int> AddFileAsync(FileStoreDTO filestore);
    }
}
