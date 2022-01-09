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

        public async Task<List<AllFoodsAndProductsDto>> SearchByName(string name)
        {

            var foods = _appDbContext.Foods.Where(w => w.FoodName.ToLower().Contains(name.ToLower()) || name == null).ToList();
            var products = _appDbContext.Products.Where(w => w.ProductName.ToLower().Contains(name.ToLower()) || name == null).ToList();


            List<AllFoodsAndProductsDto> allFoodsList = new List<AllFoodsAndProductsDto>();

            foreach (var item in foods)
            {

                AllFoodsAndProductsDto foodsList = new AllFoodsAndProductsDto
                {
                    Name = item.FoodName,
                    Carb = item.Carb,
                    Fat = item.Fat,
                    Id = item.FoodId,
                    Kcal = item.Kcal,
                    Protein = item.Protein,
                    Type = false
                };

                allFoodsList.Add(foodsList);
            }


            foreach (var item in products)
            {

                AllFoodsAndProductsDto productsList = new AllFoodsAndProductsDto
                {
                    Name = item.ProductName,
                    Carb = item.Carb,
                    Fat = item.Fat,
                    Id = item.ProductId,
                    Kcal = item.Kcal,
                    Protein = item.Protein,
                    Type = true
                };

                allFoodsList.Add(productsList);
            }


            return allFoodsList;
        }
    }
}
