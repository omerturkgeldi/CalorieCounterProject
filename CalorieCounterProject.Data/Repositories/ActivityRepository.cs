using CalorieCounterProject.Core.Models;
using CalorieCounterProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Data.Repositories
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public ActivityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Activity> GetByNameAsync(string activityName)
        {
            return await _appDbContext.Activities.Where(x => x.Name == activityName).FirstOrDefaultAsync();
        }

    }
}
