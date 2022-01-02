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
    public class DailyStepsController : ControllerBase
    {

        private readonly IDailyStepService _dailyStepService;
        private readonly IMapper _mapper;


        public DailyStepsController(IDailyStepService dailyStepService, IMapper mapper)
        {
            _dailyStepService = dailyStepService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dailySteps = await _dailyStepService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<DailyStepsDto>>(dailySteps));
        }


        [ServiceFilter(typeof(GenericNotFoundFilter<DailySteps>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dailyStep = await _dailyStepService.GetByIdAsync(id);
            return Ok(_mapper.Map<DailyStepsDto>(dailyStep));
        }


        [HttpPost]
        public async Task<IActionResult> Save(DailyStepsDto dailyStepsDto)
        {
            var newDailySteps = await _dailyStepService.AddAsync(_mapper.Map<DailySteps>(dailyStepsDto));
            return Created(string.Empty, _mapper.Map<DailyStepsDto>(newDailySteps));
        }


        [HttpPut]
        public IActionResult Update(DailyStepsDto dailyStepsDto)
        {
            var dailyStep = _dailyStepService.Update(_mapper.Map<DailySteps>(dailyStepsDto));
            return NoContent();
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<DailySteps>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var dailyStep = _dailyStepService.GetByIdAsync(id).Result;
            _dailyStepService.Remove(dailyStep);
            return NoContent();
        }

    }
}
