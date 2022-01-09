using CalorieCounterProject.Core.DTOs;
using CalorieCounterProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounterProject.API.Filters
{
    public class FoodNotFoundFilter: ActionFilterAttribute
    {

        private readonly IFoodService _foodService;

        public FoodNotFoundFilter(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var food = await _foodService.GetByIdAsync(id);

            if(food != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;

                errorDto.Errors.Add($"id'si {id} olan yemek veritabanında bulunamadı");
                context.Result = new NotFoundObjectResult(errorDto);

            }

        }

    }
}
