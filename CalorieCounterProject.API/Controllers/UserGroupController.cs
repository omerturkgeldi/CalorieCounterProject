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
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupService _userGroupService;
        private readonly IMapper _mapper;


        public UserGroupController(IUserGroupService userGroupService, IMapper mapper)
        {
            _userGroupService = userGroupService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userGroups = await _userGroupService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserGroupDto>>(userGroups));
        }


        [ServiceFilter(typeof(GenericNotFoundFilter<UserGroup>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userGroup = await _userGroupService.GetByIdAsync(id);
            return Ok(_mapper.Map<UserGroupDto>(userGroup));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserGroupDto userGroupDto)
        {
            var userGroup = await _userGroupService.AddAsync(_mapper.Map<UserGroup>(userGroupDto));
            return Created(string.Empty, _mapper.Map<UserGroupDto>(userGroup));
        }


        [HttpPut]
        public IActionResult Update(UserGroupDto userGroupDto)
        {
            var userGroup = _userGroupService.Update(_mapper.Map<UserGroup>(userGroupDto));
            return NoContent();
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<UserGroup>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var userGroup = _userGroupService.GetByIdAsync(id).Result;
            _userGroupService.Remove(userGroup);
            return NoContent();
        }


    }
}
