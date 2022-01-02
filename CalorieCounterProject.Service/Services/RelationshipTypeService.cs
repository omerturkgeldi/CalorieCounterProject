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
    public class RelationshipTypeService : Service<RelationshipType>, IRelationshipTypeService
    {
        public RelationshipTypeService(IUnitOfWork unitOfWork, IRepository<RelationshipType> repository) : base(unitOfWork, repository)
        {
        }

    }

}
