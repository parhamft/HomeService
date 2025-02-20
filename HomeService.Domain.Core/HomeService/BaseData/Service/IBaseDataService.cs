using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.BaseData.Service
{
    public interface IBaseDataService
    {
        Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellation);
    }
}
