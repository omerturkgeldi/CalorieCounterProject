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
    public class DailyProductIntakeRepository : Repository<DailyProductIntake>, IDailyProductIntakeRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public DailyProductIntakeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<DailyProductIntakeWithProductInfoDto>> GetCertainDate(DateTime dateTime)
        {

            var productsInfo = await (from dpi in _appDbContext.DailyProductIntakes
                                join prd in _appDbContext.Products on dpi.ProductId equals prd.ProductId
                                where dpi.Date.Date == dateTime.Date
                                select new { dpi.Id, dpi.ProductId, dpi.UserId, dpi.PortionSize, dpi.Date, dpi.IntakeType, prd.Kcal, prd.Fat, prd.Protein, prd.BarcodeNo, prd.ProductName, prd.Carb }).ToListAsync();

            List<DailyProductIntakeWithProductInfoDto> productDtoList = new List<DailyProductIntakeWithProductInfoDto>();

            foreach (var item in productsInfo)
            {

                DailyProductIntakeWithProductInfoDto dpiwpi = new DailyProductIntakeWithProductInfoDto
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    UserId = item.UserId,
                    PortionSize = item.PortionSize,
                    Date = item.Date,
                    BarcodeNo = item.BarcodeNo,
                    ProductName = item.ProductName,
                    IntakeType = item.IntakeType,
                    Kcal = item.Kcal,
                    Carb = item.Carb,
                    Protein = item.Protein,
                    Fat = item.Fat
                };

                productDtoList.Add(dpiwpi);
            }

            return productDtoList;

        }

        public async Task<List<DailyCalorieIntakeDto>> SearchByUserAndDate(DateAndUserIdDto dateAndUserIdDto)
        {
            var productIntakes = await (from dpi in _appDbContext.DailyProductIntakes
                                        join prd in _appDbContext.Products on dpi.ProductId equals prd.ProductId
                                        where dpi.Date.Date == dateAndUserIdDto.Date.Date
                                        where dpi.UserId.ToString() == dateAndUserIdDto.Id
                                        select new { dpi.Id, dpi.ProductId, dpi.UserId, dpi.PortionSize, dpi.Date, dpi.IntakeType, prd.Kcal, prd.Fat, prd.Protein, prd.BarcodeNo, prd.ProductName, prd.Carb }).ToListAsync();


            var foodIntakes = await (from dfi in _appDbContext.DailyFoodIntakes
                                     join foods in _appDbContext.Foods on dfi.FoodId equals foods.FoodId
                                     where dfi.Date.Date == dateAndUserIdDto.Date.Date
                                     where dfi.UserId.ToString() == dateAndUserIdDto.Id
                                     select new { dfi.Id, dfi.FoodId, dfi.UserId, dfi.PortionSize, dfi.Date, dfi.IntakeType, foods.Kcal, foods.Fat, foods.Protein, foods.FoodName, foods.Carb }).ToListAsync();




            List<DailyCalorieIntakeDto> dailyCalorieIntakesList = new List<DailyCalorieIntakeDto>();

            foreach (var item in productIntakes)
            {

                DailyCalorieIntakeDto dailyCalorieIntakeDto = new DailyCalorieIntakeDto
                {
                    Id = item.Id,
                    Carb = item.Carb,
                    Date = item.Date,
                    Fat = item.Fat,
                    IntakeType = item.IntakeType,
                    Kcal = item.Kcal,
                    Name = item.ProductName,
                    PortionSize = item.PortionSize,
                    Protein = item.Protein,
                    Type = true,
                    UserId = item.UserId,
                    BarcodeNo = item.BarcodeNo
                };

                dailyCalorieIntakesList.Add(dailyCalorieIntakeDto);
            }



            foreach (var item in foodIntakes)
            {

                DailyCalorieIntakeDto dailyCalorieIntakeDto = new DailyCalorieIntakeDto
                {
                    Id = item.Id,
                    Carb = item.Carb,
                    Date = item.Date,
                    Fat = item.Fat,
                    IntakeType = item.IntakeType,
                    Kcal = item.Kcal,
                    Name = item.FoodName,
                    PortionSize = item.PortionSize,
                    Protein = item.Protein,
                    Type = false,
                    UserId = item.UserId,
                    BarcodeNo = ""
                };

                dailyCalorieIntakesList.Add(dailyCalorieIntakeDto);
            }

            return dailyCalorieIntakesList;


        }
    }
}
