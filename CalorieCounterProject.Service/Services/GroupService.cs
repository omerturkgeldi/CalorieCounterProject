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
    public class GroupService : Service<Group>, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork, IRepository<Group> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Group> AddNewAsync(Group group)
        {
            group.CreatedAt = DateTime.UtcNow;
            await _unitOfWork.Groups.AddAsync(group);
            await _unitOfWork.CommitAsync();
            return group;
        }
     
    }

}
