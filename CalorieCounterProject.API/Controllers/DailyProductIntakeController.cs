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
    public class DailyProductIntakeController : ControllerBase
    {
        private readonly IDailyProductIntakeService _dailyProductIntakeService;
        private readonly IMapper _mapper;


        public DailyProductIntakeController(IDailyProductIntakeService dailyProductIntakeService, IMapper mapper)
        {
            _dailyProductIntakeService = dailyProductIntakeService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dailyProductIntakes = await _dailyProductIntakeService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<DailyProductIntakeDto>>(dailyProductIntakes));
        }

        [HttpPost]
        public async Task<IActionResult> GetCertainDate(DateTimeDto dateTimeDto)
        {
            var certainDateProductIntakes = await _dailyProductIntakeService.GetCertainDate(dateTimeDto.DateTime.Date);
            return Ok(_mapper.Map<IEnumerable<DailyProductIntakeWithProductInfoDto>>(certainDateProductIntakes));
        }


        [HttpPost]
        public async Task<IActionResult> SearchByUserAndDate(DateAndUserIdDto dateAndUserIdDto)
        {
            var dailyActivities = await _dailyProductIntakeService.SearchByUserAndDate(dateAndUserIdDto);
            return Ok(_mapper.Map<IEnumerable<DailyCalorieIntakeDto>>(dailyActivities));
        }



        //[ServiceFilter(typeof(FoodNotFoundFilter))]
        [ServiceFilter(typeof(GenericNotFoundFilter<DailyProductIntake>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dailyProductIntake = await _dailyProductIntakeService.GetByIdAsync(id);
            return Ok(_mapper.Map<DailyProductIntakeDto>(dailyProductIntake));
        }


        [HttpPost]
        public async Task<IActionResult> Save(DailyProductIntakeDto dailyProductIntakeDto)
        {
            var newDailyProductIntake = await _dailyProductIntakeService.AddAsync(_mapper.Map<DailyProductIntake>(dailyProductIntakeDto));
            return Created(string.Empty, _mapper.Map<DailyProductIntakeDto>(newDailyProductIntake));
        }

        [HttpPut]
        public IActionResult Update(DailyProductIntakeDto dailyProductIntakeDto)
        {
            var dailyProductIntake = _dailyProductIntakeService.Update(_mapper.Map<DailyProductIntake>(dailyProductIntakeDto));
            return NoContent();
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<DailyProductIntake>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var dailyProductIntake = _dailyProductIntakeService.GetByIdAsync(id).Result;
            _dailyProductIntakeService.Remove(dailyProductIntake);
            return NoContent();
        }



    }
}
