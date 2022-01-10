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

        public async Task<Relationship> AddNewAsync(Relationship relationship)
        {
            return relationship;
        }

        public async Task<List<FriendDto>> SearchUsersFriends(string userId)
        {


            // userid_1 e eşitse
            var friendsList1 = await (from rlt in _appDbContext.Relationships
                                     join usrs in _appDbContext.Users on rlt.UserId_2.ToString() equals usrs.Id
                                     where rlt.UserId_1.ToString() == userId 
                                     where rlt.RelationshipTypeId == 1 || rlt.RelationshipTypeId == 2
                                     select new { rlt.Id, rlt.UserId_1, rlt.UserId_2, rlt.CreatedAt, rlt.RelationshipTypeId, usrs.City, usrs.RegisterDate, usrs.Birthdate, usrs.Weight, usrs.Height, usrs.Email, usrs.Gender, usrs.ActivityFactor, usrs.Goal, usrs.UserName, usrs.Name, usrs.Surname }).ToListAsync();

            // userid_2 e eşitse
            var friendsList2 = await (from rlt in _appDbContext.Relationships
                                      join usrs in _appDbContext.Users on rlt.UserId_1.ToString() equals usrs.Id
                                      where rlt.UserId_2.ToString() == userId 
                                      where rlt.RelationshipTypeId == 1 || rlt.RelationshipTypeId == 2
                                      select new { rlt.Id, rlt.UserId_1, rlt.UserId_2, rlt.CreatedAt, rlt.RelationshipTypeId, usrs.City, usrs.RegisterDate, usrs.Birthdate, usrs.Weight, usrs.Height, usrs.Email, usrs.Gender, usrs.ActivityFactor, usrs.Goal, usrs.UserName, usrs.Name, usrs.Surname }).ToListAsync();


            List<FriendDto> friendsList = new List<FriendDto>();


            foreach (var item in friendsList1)
            {

                FriendDto friendDto = new FriendDto
                {
                    Id = item.Id,
                    UserId_1 = item.UserId_1,
                    UserId_2 = item.UserId_2,
                    RelationshipTypeId = item.RelationshipTypeId,
                    CreatedAt = item.CreatedAt,
                    City = item.City,
                    RegisterDate = item.RegisterDate,
                    Birthdate = item.Birthdate,
                    Weight = item.Weight,
                    Height = item.Height,
                    Email = item.Email,
                    Gender = item.Gender,
                    ActivityFactor = item.ActivityFactor,
                    Goal = item.Goal,
                    Username = item.UserName,
                    Name = item.Name,
                    Surname = item.Surname

                };

                friendsList.Add(friendDto);

            }



            foreach (var item in friendsList2)
            {

                FriendDto friendDto = new FriendDto
                {
                    Id = item.Id,
                    UserId_1 = item.UserId_2, // burası ters olucak
                    UserId_2 = item.UserId_1,
                    RelationshipTypeId = item.RelationshipTypeId,
                    CreatedAt = item.CreatedAt,
                    City = item.City,
                    RegisterDate = item.RegisterDate,
                    Birthdate = item.Birthdate,
                    Weight = item.Weight,
                    Height = item.Height,
                    Email = item.Email,
                    Gender = item.Gender,
                    ActivityFactor = item.ActivityFactor,
                    Goal = item.Goal,
                    Username = item.UserName,
                    Name = item.Name,
                    Surname = item.Surname

                };

                friendsList.Add(friendDto);

            }



            return friendsList;




        }
    }

}
