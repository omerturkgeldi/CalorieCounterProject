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

        Task CommitAsync();
        void Commit();

    }
}
