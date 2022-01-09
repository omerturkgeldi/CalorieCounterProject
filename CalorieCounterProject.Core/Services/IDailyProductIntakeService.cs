using CalorieCounterProject.Core.DTOs;
using CalorieCounterProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.Services
{
    public interface IDailyProductIntakeService : IService<DailyProductIntake>
    {
        Task<List<DailyProductIntakeWithProductInfoDto>> GetCertainDate(DateTime dateTime);

        Task<List<DailyCalorieIntakeDto>> SearchByUserAndDate(DateAndUserIdDto dateAndUserIdDto);
    }

}
