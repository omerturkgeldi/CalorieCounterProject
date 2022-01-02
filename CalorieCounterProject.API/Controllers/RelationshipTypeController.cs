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
    public class RelationshipTypeController : ControllerBase
    {

        private readonly IRelationshipTypeService _relationshipTypeService;
        private readonly IMapper _mapper;


        public RelationshipTypeController(IRelationshipTypeService relationshipTypeService, IMapper mapper)
        {
            _relationshipTypeService = relationshipTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var relationshipTypes = await _relationshipTypeService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<RelationshipTypeDto>>(relationshipTypes));
        }


        [ServiceFilter(typeof(GenericNotFoundFilter<RelationshipType>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var relationshipType = await _relationshipTypeService.GetByIdAsync(id);
            return Ok(_mapper.Map<RelationshipTypeDto>(relationshipType));
        }


        [HttpPost]
        public async Task<IActionResult> Save(RelationshipTypeDto relationshipTypeDto)
        {
            var newRelationshipType = await _relationshipTypeService.AddAsync(_mapper.Map<RelationshipType>(relationshipTypeDto));
            return Created(string.Empty, _mapper.Map<RelationshipTypeDto>(newRelationshipType));
        }

        [HttpPut]
        public IActionResult Update(RelationshipTypeDto relationshipTypeDto)
        {
            var relationshipType = _relationshipTypeService.Update(_mapper.Map<RelationshipType>(relationshipTypeDto));
            return NoContent();
        }



        [ServiceFilter(typeof(GenericNotFoundFilter<RelationshipType>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var relationshipType = _relationshipTypeService.GetByIdAsync(id).Result;
            _relationshipTypeService.Remove(relationshipType);
            return NoContent();
        }


    }
}
