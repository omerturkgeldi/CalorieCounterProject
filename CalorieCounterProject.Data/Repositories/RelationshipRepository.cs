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
    public class RelationshipRepository : Repository<Relationship>, IRelationshipRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public RelationshipRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<RelationshipWithTypeDto> GetWithRelationshipTypeAsync(int relationshipId)
        {
            var query = await (from rt in _appDbContext.RelationshipTypes
                               join rltnshp in _appDbContext.Relationships on rt.Id equals rltnshp.RelationshipTypeId
                               where rltnshp.IsDeleted == false && rltnshp.Id == relationshipId
                               select new { rltnshp.Id, rltnshp.UserId_1, rltnshp.UserId_2, rltnshp.CreatedAt, rt.Type }).SingleOrDefaultAsync();

            RelationshipWithTypeDto relationshipWithTypeDto = new RelationshipWithTypeDto
            {
                Id = query.Id,
                UserId_1 = query.UserId_1,
                UserId_2 = query.UserId_2,
                CreatedAt = query.CreatedAt,
                Type = query.Type
            };

            return relationshipWithTypeDto;
                               
        }
    }

}
