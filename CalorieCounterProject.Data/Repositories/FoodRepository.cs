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
    public class FoodRepository: Repository<Food>, IFoodRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public FoodRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Food> GetByNameAsync(string foodName)
        {
            return await _appDbContext.Foods.Where(x => x.FoodName == foodName).FirstOrDefaultAsync();
        }

    }
}
