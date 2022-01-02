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
    public class DailyProductIntakeService : Service<DailyProductIntake>, IDailyProductIntakeService
    {

        public DailyProductIntakeService(IUnitOfWork unitOfWork, IRepository<DailyProductIntake> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<List<DailyProductIntakeWithProductInfoDto>> GetCertainDate(DateTime dateTime)
        {
            return await _unitOfWork.DailyProductIntakes.GetCertainDate(dateTime);
        }
    }
}
