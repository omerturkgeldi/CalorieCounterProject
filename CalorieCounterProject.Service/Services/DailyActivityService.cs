using CalorieCounterProject.Core.DTOs;
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
    public class DailyActivityService : Service<DailyActivity>, IDailyActivityService
    {

        public DailyActivityService(IUnitOfWork unitOfWork, IRepository<DailyActivity> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<DailyActivity> AddNewAsync(DailyActivity dailyActivity)
        {
            dailyActivity.Date = DateTime.UtcNow;
            await _unitOfWork.DailyActivities.AddAsync(dailyActivity);
            await _unitOfWork.CommitAsync();
            return dailyActivity;

        }

        public async Task<List<DailyActivityClientDto>> SearchByUserAndDate(DateAndUserIdDto dateAndUserIdDto)
        {
            return await _unitOfWork.DailyActivities.SearchByUserAndDate(dateAndUserIdDto);
        }
    }

}
