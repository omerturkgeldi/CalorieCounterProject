using CalorieCounterProject.API.DTOs;
using CalorieCounterProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounterProject.API.Filters
{
    public class ActivityNotFoundFilter: ActionFilterAttribute
    {

        private readonly IActivityService _activityService;

        public ActivityNotFoundFilter(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var activity = await _activityService.GetByIdAsync(id);

            if (activity != null)
            {
                await next();
            }

            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;

                errorDto.Errors.Add($"id'si {id} olan aktivite veritabanında bulunamadı");
                context.Result = new NotFoundObjectResult(errorDto);

            }

        }
    }
}
