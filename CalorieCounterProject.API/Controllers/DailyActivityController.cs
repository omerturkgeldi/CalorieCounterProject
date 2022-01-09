using AutoMapper;
using CalorieCounterProject.API.Filters;
using CalorieCounterProject.Core.DTOs;
using CalorieCounterProject.Core.Models;
using CalorieCounterProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounterProject.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DailyActivityController : ControllerBase
    {

        private readonly IDailyActivityService _dailyActivityService;
        private readonly IMapper _mapper;


        public DailyActivityController(IDailyActivityService dailyActivityService, IMapper mapper)
        {
            _dailyActivityService = dailyActivityService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dailyActivities = await _dailyActivityService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<DailyActivityDto>>(dailyActivities));
        }


        [HttpPost]
        public async Task<IActionResult> SearchByUserAndDate(DateAndUserIdDto dateAndUserIdDto)
        {
            var dailyActivities = await _dailyActivityService.SearchByUserAndDate(dateAndUserIdDto);
            return Ok(_mapper.Map<IEnumerable<DailyActivityClientDto>>(dailyActivities));
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<DailyActivity>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dailyActivity = await _dailyActivityService.GetByIdAsync(id);
            return Ok(_mapper.Map<DailyActivityDto>(dailyActivity));
        }


        [HttpPost]
        public async Task<IActionResult> Save(DailyActivity dailyActivity)
        {
            var newDailyActivity = await _dailyActivityService.AddNewAsync(_mapper.Map<DailyActivity>(dailyActivity));
            return Created(string.Empty, _mapper.Map<DailyActivityDto>(newDailyActivity));
        }


        [HttpPut]
        public IActionResult Update(DailyActivityDto dailyActivityDto)
        {
            var dailyActivity = _dailyActivityService.Update(_mapper.Map<DailyActivity>(dailyActivityDto));
            return NoContent();
        }


        [ServiceFilter(typeof(GenericNotFoundFilter<DailyActivity>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var dailyActivity = _dailyActivityService.GetByIdAsync(id).Result;
            _dailyActivityService.Remove(dailyActivity);
            return NoContent();
        }


    }
}
