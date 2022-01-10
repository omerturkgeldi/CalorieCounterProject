using CalorieCounterProject.Core.DTOs;
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
    public class RelationshipService : Service<Relationship>, IRelationshipService
    {
        public RelationshipService(IUnitOfWork unitOfWork, IRepository<Relationship> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Relationship> AddNewAsync(Relationship relationship)
        {
            relationship.CreatedAt = DateTime.UtcNow;
            await _unitOfWork.Relationships.AddAsync(relationship);
            await _unitOfWork.CommitAsync();
            return relationship;
        }

        public async Task<RelationshipWithTypeDto> GetWithRelationshipTypeAsync(int relationship)
        {
            return await _unitOfWork.Relationships.GetWithRelationshipTypeAsync(relationship);
        }

        public async Task<List<FriendDto>> SearchUsersFriends(string userId)
        {
            return await _unitOfWork.Relationships.SearchUsersFriends(userId);
        }
    }
}
