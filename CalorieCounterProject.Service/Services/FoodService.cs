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
    public class FoodService : Service<Food>, IFoodService
    {
        public FoodService(IUnitOfWork unitOfWork, IRepository<Food> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Food> GetByNameAsync(string foodName)
        {
            return await _unitOfWork.Foods.GetByNameAsync(foodName);

        }

        // ????
        new public async Task<Food> AddAsync(Food food)
        {
            //food.UrlName = 
            food.RegisterDate = DateTime.UtcNow;
            await _repository.AddAsync(food);
            await _unitOfWork.CommitAsync();
            return food;
        }

    }
}
