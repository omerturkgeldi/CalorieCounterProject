using AutoMapper;
using CalorieCounterProject.API.DTOs;
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
        }


    }
}
