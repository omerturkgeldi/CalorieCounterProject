using AutoMapper;
using CalorieCounterProject.Core.DTOs;
using CalorieCounterProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounterProject.API.Mapping
{
    public class MapProfile: Profile
    {

        public MapProfile()
        {
            CreateMap<Food, FoodDto>();
            CreateMap<FoodDto, Food>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Activity, ActivityDto>();
            CreateMap<ActivityDto, Activity>();

            CreateMap<DailyProductIntake, DailyProductIntakeDto>();
            CreateMap<DailyProductIntakeDto, DailyProductIntake>();

            CreateMap<DailyFoodIntake, DailyFoodIntakeDto>();
            CreateMap<DailyFoodIntakeDto, DailyFoodIntake>();

            CreateMap<DailyActivity, DailyActivityDto>();
            CreateMap<DailyActivityDto, DailyActivity>();

            CreateMap<DailySteps, DailyStepsDto>();
            CreateMap<DailyStepsDto, DailySteps>();

            CreateMap<Group, GroupDto>();
            CreateMap<GroupDto, Group>();

            CreateMap<UserGroup, UserGroupDto>();
            CreateMap<UserGroupDto, UserGroup>();

            CreateMap<RelationshipType, RelationshipTypeDto>();
            CreateMap<RelationshipTypeDto, RelationshipType>();

            CreateMap<Relationship, RelationshipDto>();
            CreateMap<RelationshipDto, Relationship>();
        }

    }
}
