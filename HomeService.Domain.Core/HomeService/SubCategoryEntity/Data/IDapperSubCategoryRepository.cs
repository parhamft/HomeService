﻿using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.SubCategoryEntity.Data
{
    public interface IDapperSubCategoryRepository
    {
        Task<List<GetSubCategoryDTO>> GetAllSubCategoryDapper(CancellationToken cancellationToken);

    }
}
