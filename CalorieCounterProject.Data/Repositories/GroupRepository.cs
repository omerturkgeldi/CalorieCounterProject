using CalorieCounterProject.Core.Models;
using CalorieCounterProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public GroupRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Group> AddNewAsync(Group group)
        {
            return group;
        }
    }
}
