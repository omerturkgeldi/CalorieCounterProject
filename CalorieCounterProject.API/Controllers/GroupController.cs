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
    public class GroupController : ControllerBase
    {

        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;


        public GroupController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _groupService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GroupDto>>(groups));
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Group>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _groupService.GetByIdAsync(id);
            return Ok(_mapper.Map<GroupDto>(group));
        }


        [HttpPost]
        public async Task<IActionResult> Save(GroupDto groupDto)
        {
            var newGroup = await _groupService.AddAsync(_mapper.Map<Group>(groupDto));
            return Created(string.Empty, _mapper.Map<GroupDto>(newGroup));
        }

        [HttpPut]
        public IActionResult Update(GroupDto groupDto)
        {
            var group = _groupService.Update(_mapper.Map<Group>(groupDto));
            return NoContent();
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Group>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var group = _groupService.GetByIdAsync(id).Result;
            _groupService.Remove(group);
            return NoContent();
        }


    }
}
