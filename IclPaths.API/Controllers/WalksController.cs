using IclPaths.API.CustomActionFilters;
using IclPaths.API.Domain.Interfaces.WalkPathInterfaces;
using IclPaths.API.Models.DTO.WalkDTOs;
using IclPaths.API.Models.DTO.WalkPathDTOs;
using Microsoft.AspNetCore.Mvc;

namespace IclPaths.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkPathRepository _walkPathRepository;

        public WalksController(IWalkPathRepository walkPathRepository)
        {
            _walkPathRepository = walkPathRepository;
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddWalk([FromBody] AddWalkPathDto addWalkPathDto)
        {
            var result = await _walkPathRepository.AddWalkAsync(addWalkPathDto);
            return CreatedAtAction(nameof(GetWalk), new { id = result.Id }, result);
        }

        [HttpGet]
        [Route("/getAll")]
        public async Task<IActionResult> GetWalks()
        {
            var walks = await _walkPathRepository.GetAllWalkPathsAsync();
            return Ok(walks);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [NotFoundIfNull]
        public async Task<IActionResult> GetWalk([FromRoute] Guid id)
        {
            var walks = await _walkPathRepository.GetWalkPathByIdAsync(id);
            return Ok(walks);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [NotFoundIfNull]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalkPathDto updateWalkPathDto)
        {
            var result = await _walkPathRepository.UpdateWalkPathAsync(id, updateWalkPathDto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [NotFoundIfNull]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var result = await _walkPathRepository.DeleteWalkPathAsync(id);
            return Ok(result);
        }
        [HttpGet]
        [NotFoundIfNull]
        public async Task<IActionResult> GetWalkPaths([FromQuery] Guid? regionId, [FromQuery] Guid? difficultyId)
        {
            var walks = await _walkPathRepository.GetWalkPathsAsync(regionId, difficultyId);
            return Ok(walks);
        }
    }
}
