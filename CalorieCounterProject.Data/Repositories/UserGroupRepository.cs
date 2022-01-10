using CalorieCounterProject.Core.Models;
using CalorieCounterProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Data.Repositories
{
    public class UserGroupRepository : Repository<UserGroup>, IUserGroupRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public UserGroupRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<UserGroup> AddNewAsync(UserGroup userGroup)
        {
            return userGroup;
        }
    }
}
