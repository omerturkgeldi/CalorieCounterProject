using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounterProject.Core.Repositories;
using CalorieCounterProject.Core.UnitOfWorks;
using CalorieCounterProject.Data.Repositories;

namespace CalorieCounterProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private FoodRepository _foodRepository;
        private ProductRepository _productRepository;
        private ActivityRepository _activityRepository;

        public IFoodRepository Foods => _foodRepository = _foodRepository ?? new FoodRepository(_context);

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public IActivityRepository Activities => _activityRepository = _activityRepository ?? new ActivityRepository(_context);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
