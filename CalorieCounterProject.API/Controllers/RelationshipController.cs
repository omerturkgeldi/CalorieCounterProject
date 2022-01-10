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
    public class RelationshipController : ControllerBase
    {

        private readonly IRelationshipService _relationshipService;
        private readonly IMapper _mapper;


        public RelationshipController(IRelationshipService relationshipService, IMapper mapper)
        {
            _relationshipService = relationshipService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var relationships = await _relationshipService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<RelationshipDto>>(relationships));
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Relationship>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var relationship = await _relationshipService.GetWithRelationshipTypeAsync(id);
            return Ok(_mapper.Map<RelationshipWithTypeDto>(relationship));
        }

        [HttpPost]
        public async Task<IActionResult> Save(RelationshipDto relationshipDto)
        {
            var newRelationship = await _relationshipService.AddNewAsync(_mapper.Map<Relationship>(relationshipDto));
            return Created(string.Empty, _mapper.Map<RelationshipDto>(newRelationship));
        }

        [HttpPut]
        public IActionResult Update(RelationshipDto relationshipDto)
        {
            var relationship = _relationshipService.Update(_mapper.Map<Relationship>(relationshipDto));
            return NoContent();
        }


        [ServiceFilter(typeof(GenericNotFoundFilter<Relationship>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var relationship = _relationshipService.GetByIdAsync(id).Result;
            _relationshipService.Remove(relationship);
            return NoContent();
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchUsersFriends(string userId)
        {
            var allFriends = await _relationshipService.SearchUsersFriends(userId);
            return Ok(_mapper.Map<IEnumerable<FriendDto>>(allFriends));
        }





    }
}
