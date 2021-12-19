using AutoMapper;
using CalorieCounterProject.API.DTOs;
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
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly IMapper _mapper;


        public FoodsController(IFoodService foodService, IMapper mapper)
        {
            _foodService = foodService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var foods = await _foodService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<FoodDto>>(foods));
        }


        //[ServiceFilter(typeof(FoodNotFoundFilter))]
        [ServiceFilter(typeof(GenericNotFoundFilter<Food>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var food = await _foodService.GetByIdAsync(id);
            return Ok(_mapper.Map<FoodDto>(food));
        }


        //[ServiceFilter(typeof(GenericNotFoundFilter<Food>))]
        //TODO: name ile sorgular için GenericNotFoundFilter yaz.
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var food = await _foodService.GetByNameAsync(name);
            return Ok(_mapper.Map<FoodDto>(food));
        }

        [HttpPost]
        public async Task<IActionResult> Save(FoodDto foodDto)
        {
            var newFood = await _foodService.AddAsync(_mapper.Map<Food>(foodDto));
            newFood.RegisterDate = DateTime.UtcNow;
            return Created(string.Empty, _mapper.Map<FoodDto>(newFood));
        }

        [HttpPut]
        public IActionResult Update(FoodDto foodDto)
        {
            var food = _foodService.Update(_mapper.Map<Food>(foodDto));
            return NoContent();
        }


        [ServiceFilter(typeof(GenericNotFoundFilter<Food>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var food = _foodService.GetByIdAsync(id).Result;
            _foodService.Remove(food);
            return NoContent();
        }






    }
}
