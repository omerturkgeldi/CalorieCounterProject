using CalorieCounterProject.Core.Models;
using CalorieCounterProject.Core.Repositories;
using CalorieCounterProject.Core.Services;
using CalorieCounterProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Service.Services
{
    public class UserGroupService : Service<UserGroup>, IUserGroupService
    {
        public UserGroupService(IUnitOfWork unitOfWork, IRepository<UserGroup> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<UserGroup> AddNewAsync(UserGroup userGroup)
        {
            userGroup.DateAdded = DateTime.UtcNow;
            await _unitOfWork.UserGroups.AddAsync(userGroup);
            await _unitOfWork.CommitAsync();
            return userGroup;
        }

    }
}
