using CalorieCounterProject.Core.DTOs;
using CalorieCounterProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.Repositories
{
    public interface IFoodRepository: IRepository<Food>
    {
        Task<Food> GetByNameAsync(string foodName);
        Task<List<AllFoodsAndProductsDto>> SearchByName(string name);

    }
}
