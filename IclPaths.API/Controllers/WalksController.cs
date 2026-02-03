using AutoMapper;
using IclPaths.API.Domain.Interfaces.WalkPathInterfaces;
using IclPaths.API.Domain.Repositories.WalkPathRepository;
using IclPaths.API.Models.Domain;
using IclPaths.API.Models.DTO.WalkDTOs;
using IclPaths.API.Models.DTO.WalkPathDTOs;
using Microsoft.AspNetCore.Mvc;

namespace IclPaths.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IWalkPathRepository _walkPathRepository;

        public WalksController(IMapper mapper, IWalkPathRepository walkPathRepository)
        {
            _mapper = mapper;
            _walkPathRepository = walkPathRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddWalk([FromBody] AddWalkPathDto addWalkPathDto)
        {
            var result = await _walkPathRepository.AddWalkAsync(addWalkPathDto);
            return CreatedAtAction(nameof(GetWalk), new { id = result.Id }, result);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalk([FromRoute] Guid id)
        {
            var walks = await _walkPathRepository.GetWalkPathByIdAsync(id);
            if (walks == null)
            {
                return NotFound();
            }
            return Ok(walks);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalkPathDto updateWalkPathDto)
        {
            var result = await _walkPathRepository.UpdateWalkPathAsync(id, updateWalkPathDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var result = await _walkPathRepository.DeleteWalkPathAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetWalkPaths([FromQuery] Guid? regionId, [FromQuery] Guid? difficultyId)
        {
            var walks = await _walkPathRepository.GetWalkPathsAsync(regionId, difficultyId);
            return Ok(walks);
        }
    }
}
