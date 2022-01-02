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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DailyFoodIntakeController : ControllerBase
    {

        private readonly IDailyFoodIntakeService _dailyFoodIntakeService;
        private readonly IMapper _mapper;


        public DailyFoodIntakeController(IDailyFoodIntakeService dailyFoodIntakeService, IMapper mapper)
        {
            _dailyFoodIntakeService = dailyFoodIntakeService;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dailyFoodtIntakes = await _dailyFoodIntakeService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<DailyFoodIntakeDto>>(dailyFoodtIntakes));
        }


        [ServiceFilter(typeof(GenericNotFoundFilter<DailyFoodIntake>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dailyFoodIntake = await _dailyFoodIntakeService.GetByIdAsync(id);
            return Ok(_mapper.Map<DailyFoodIntakeDto>(dailyFoodIntake));
        }


        [HttpPost]
        public async Task<IActionResult> Save(DailyFoodIntakeDto dailyFoodIntakeDto)
        {
            var newDailyFoodIntake = await _dailyFoodIntakeService.AddAsync(_mapper.Map<DailyFoodIntake>(dailyFoodIntakeDto));
            return Created(string.Empty, _mapper.Map<DailyFoodIntakeDto>(newDailyFoodIntake));
        }


        [HttpPut]
        public IActionResult Update(DailyFoodIntakeDto dailyFoodIntakeDto)
        {
            var dailyFoodIntake = _dailyFoodIntakeService.Update(_mapper.Map<DailyFoodIntake>(dailyFoodIntakeDto));
            return NoContent();
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<DailyFoodIntake>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var dailyFoodIntake = _dailyFoodIntakeService.GetByIdAsync(id).Result;
            _dailyFoodIntakeService.Remove(dailyFoodIntake);
            return NoContent();
        }

    }
}
