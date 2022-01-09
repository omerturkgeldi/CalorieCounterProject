using CalorieCounterProject.Core.Models;
using CalorieCounterProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Data.Repositories
{
    public class DailyStepRepository : Repository<DailySteps>, IDailyStepRepository
    {

        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public DailyStepRepository(AppDbContext context) : base(context)
        {
        }


    }
}
