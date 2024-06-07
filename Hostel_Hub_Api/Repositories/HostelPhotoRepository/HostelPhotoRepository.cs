using Hostel_Hub_Api.Models;
using Hostel_Hub_Api.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Repositories.HostelPhotoRepository
{
    public class HostelPhotoRepository : BaseRepository<HostelPhoto>, IHostelPhotoRepository
    {
        public HostelPhotoRepository(Hostel_HubContext dbContext) : base(dbContext)
        {
        }
    }
}
