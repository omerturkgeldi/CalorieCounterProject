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
        private RelationshipRepository _relationshipRepository;
        private DailyProductIntakeRepository _dailyProductIntakeRepository;
        private DailyStepRepository _dailyStepRepository;
        private DailyActivityRepository _dailyActivityRepository;
        private UserGroupRepository _userGroupRepository;
        private GroupRepository _groupRepository;
        //private DailyFoodIntakeRepository dailyFoodIntakeRepository;
        //private DailyActivityRepository dailyActivityRepository;
        //private GroupRepository groupRepository;
        //private UserGroupRepository userGroupRepository;


        public IFoodRepository Foods => _foodRepository = _foodRepository ?? new FoodRepository(_context);

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public IActivityRepository Activities => _activityRepository = _activityRepository ?? new ActivityRepository(_context);

        public IRelationshipRepository Relationships => _relationshipRepository = _relationshipRepository ?? new RelationshipRepository(_context);

        public IDailyProductIntakeRepository DailyProductIntakes => _dailyProductIntakeRepository = _dailyProductIntakeRepository ?? new DailyProductIntakeRepository(_context);

        public IDailyStepRepository DailySteps => _dailyStepRepository = _dailyStepRepository ?? new DailyStepRepository(_context);

        public IDailyActivityRepository DailyActivities => _dailyActivityRepository = _dailyActivityRepository ?? new DailyActivityRepository(_context);

        public IUserGroupRepository UserGroups => _userGroupRepository = _userGroupRepository ?? new UserGroupRepository(_context);

        public IGroupRepository Groups => _groupRepository = _groupRepository ?? new GroupRepository(_context);

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
