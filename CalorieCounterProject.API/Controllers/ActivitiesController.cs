using AutoMapper;
using CalorieCounterProject.Core.DTOs;
using CalorieCounterProject.API.Filters;
using CalorieCounterProject.Core.Models;
using CalorieCounterProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounterProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;


        public ActivitiesController(IActivityService activityService, IMapper mapper)
        {
            _activityService = activityService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activities = await _activityService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ActivityDto>>(activities));
        }


        [HttpGet]
        public async Task<IActionResult> SearchByActivityName(string name)
        {
            var activities = await _activityService.SearchByActivityName(name);
            return Ok(_mapper.Map<IEnumerable<ActivityDto>>(activities));
        }



        //[ServiceFilter(typeof(ActivityNotFoundFilter))]
        [ServiceFilter(typeof(GenericNotFoundFilter<Activity>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var activity = await _activityService.GetByIdAsync(id);
            return Ok(_mapper.Map<ActivityDto>(activity));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ActivityDto activityDto)
        {
            var newActivity = await _activityService.AddAsync(_mapper.Map<Activity>(activityDto));
            return Created(string.Empty, _mapper.Map<ActivityDto>(newActivity));
        }


        [HttpPost]
        public async Task<IActionResult> SaveAll(List<ActivityDto> activityDtos)
        {
            var newActivity = await _activityService.AddRangeAsync(_mapper.Map<IEnumerable<Activity>>(activityDtos));
            return Created(string.Empty, _mapper.Map<ActivityDto>(newActivity));
        }



        [HttpPut]
        public IActionResult Update(ActivityDto activityDto)
        {
            var activity = _activityService.Update(_mapper.Map<Activity>(activityDto));
            return NoContent();
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Activity>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var activity = _activityService.GetByIdAsync(id).Result;
            _activityService.Remove(activity);
            return NoContent();
        }

    }
}
