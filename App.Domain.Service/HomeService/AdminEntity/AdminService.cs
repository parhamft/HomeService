using HomeService.Domain.Core.HomeService.AdminEntity.Data;
using HomeService.Domain.Core.HomeService.AdminEntity.DTO;
using HomeService.Domain.Core.HomeService.AdminEntity.Entities;
using HomeService.Domain.Core.HomeService.AdminEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.HomeService.AdminEntity
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<List<Admin>> GetAll(CancellationToken cancellationToken)
        {
            return await _adminRepository.GetAll(cancellationToken);
        }
        public async Task<Admin> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _adminRepository.GetById(Id, cancellationToken);
        }
        public async Task<UpdateAdminDTO> GetUpdateDTO(int Id, CancellationToken cancellationToken)
        {
            return await _adminRepository.GetUpdateDTO(Id, cancellationToken);
        }
        public async Task<bool> Update(UpdateAdminDTO adminDTO, CancellationToken cancellationToken)
        {
            return await _adminRepository.Update(adminDTO, cancellationToken);
        }

    }
}
