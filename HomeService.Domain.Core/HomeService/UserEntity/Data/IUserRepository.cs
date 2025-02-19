using HomeService.Domain.Core.HomeService.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.UserEntity.Data
{
    public interface IUserRepository
    {
         Task<List<User>> GetAll(CancellationToken cancellationToken);
         Task<User> GetById(int Id, CancellationToken cancellationToken);
         Task<bool> Create(User user, CancellationToken cancellationToken);
         Task<bool> Update(User user, CancellationToken cancellationToken);
         Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}
