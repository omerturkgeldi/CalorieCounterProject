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
    public class DailyActivityRepository : Repository<DailyActivity>, IDailyActivityRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public DailyActivityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<DailyActivity> AddNewAsync(DailyActivity dailyActivity)
        {
            //dailyActivity.Date = DateTime.UtcNow;
            return dailyActivity;
        }

        public async Task<List<DailyActivityClientDto>> SearchByUserAndDate(DateAndUserIdDto dateAndUserIdDto)
        {
            var activities = _appDbContext.DailyActivities.Where(w => w.UserId.ToString() == dateAndUserIdDto.Id && w.Date.Date == dateAndUserIdDto.Date.Date).ToList();
            var userWeight = _appDbContext.Users.Where(w => w.Id == dateAndUserIdDto.Id.ToString()).Select(w => w.Weight).FirstOrDefault();

            List<DailyActivityClientDto> dailyActivityList = new List<DailyActivityClientDto>();

            foreach (var item in activities)
            {
                var activityInfo = _appDbContext.Activities.Where(w => w.ActivityId == item.ActivityId).FirstOrDefault();



                DailyActivityClientDto dailyActivityClientDto = new DailyActivityClientDto
                {
                    Id = item.Id,
                    ActivityId = item.ActivityId,
                    Date = item.Date,
                    Minutes = item.Minutes,
                    UserId = item.UserId,
                    SpecificMotion = activityInfo.SpecificMotion,
                    Weight = userWeight,
                    METValue = activityInfo.MetValue,
                };


                dailyActivityList.Add(dailyActivityClientDto);
            }

            return dailyActivityList;

        }
    }
}
