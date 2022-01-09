using CalorieCounterProject.Core.DTOs;
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

        public async Task<List<ActivityDto>> SearchByActivityName(string name)
        {
            var result = _appDbContext.Activities.Where(q => q.SpecificMotion.ToLower().Contains(name.ToLower()) || q.Name.ToLower().Contains(name.ToLower()) || name == null).ToList();

            List<ActivityDto> activityList = new List<ActivityDto>();


            foreach (var item in result)
            {

                ActivityDto activity = new ActivityDto
                {
                    ActivityId = item.ActivityId,
                    Name = item.Name,
                    SpecificMotion = item.SpecificMotion,
                    METValue = item.MetValue
                };

                activityList.Add(activity);
            }


            return activityList;
        }
    }
}
