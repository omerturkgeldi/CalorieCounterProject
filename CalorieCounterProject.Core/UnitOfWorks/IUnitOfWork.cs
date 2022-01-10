using CalorieCounterProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IFoodRepository Foods { get; }
        IProductRepository Products { get; }
        IActivityRepository Activities { get; }
        IRelationshipRepository Relationships { get; }
        IDailyProductIntakeRepository DailyProductIntakes { get; }
        //IDailyFoodIntakeRepository DailyFoodIntakes { get; }
        IDailyStepRepository DailySteps { get; }
        IDailyActivityRepository DailyActivities { get; }
        IUserGroupRepository UserGroups { get; }
        IGroupRepository Groups { get; }
        //IGroupRepository Groups { get; }
        //IRelationshipTypeRepository RelationshipTypes { get; }




        Task CommitAsync();
        void Commit();

    }
}
