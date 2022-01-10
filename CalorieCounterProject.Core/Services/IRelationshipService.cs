using CalorieCounterProject.Core.DTOs;
using CalorieCounterProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CalorieCounterProject.Core.Services
{
    public interface  IRelationshipService : IService<Relationship>
    {
        Task<RelationshipWithTypeDto> GetWithRelationshipTypeAsync(int relationshipId);
        Task<Relationship> AddNewAsync(Relationship relationship);
        Task<List<FriendDto>> SearchUsersFriends(string userId);
    }
}
