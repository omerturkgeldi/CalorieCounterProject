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

            var queryy = await (from dpi in _appDbContext.DailyProductIntakes
                                join prd in _appDbContext.Products on dpi.ProductId equals prd.ProductId
                                where dpi.Date.Date == dateTime.Date
                                select new { dpi.Id, dpi.ProductId, dpi.UserId, dpi.PortionSize, dpi.Date, dpi.IntakeType, prd.Kcal, prd.Fat, prd.Protein, prd.BarcodeNo, prd.ProductName, prd.Carb }).ToListAsync();

            List<DailyProductIntakeWithProductInfoDto> mylist = new List<DailyProductIntakeWithProductInfoDto>();

            foreach (var item in queryy)
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

                mylist.Add(dpiwpi);
            }

            return mylist;

        }
    }
}
